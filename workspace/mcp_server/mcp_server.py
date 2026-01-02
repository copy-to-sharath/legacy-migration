import argparse
import json
import logging
import sys
import threading
import time
from http.server import BaseHTTPRequestHandler, ThreadingHTTPServer
from pathlib import Path
from typing import Any, Dict, List, Optional, Tuple

from neo4j import GraphDatabase
from neo4j.graph import Node, Path as Neo4jPath, Relationship
from qdrant_client import QdrantClient


WORKSPACE_ROOT = Path(__file__).resolve().parents[1]
PROMPTS_DIR = WORKSPACE_ROOT / "prompts"
SYSTEM_PROMPTS_PATH = PROMPTS_DIR / "system-prompts.md"


class PromptStore:
    def __init__(self, prompts_path: Path) -> None:
        self._path = prompts_path

    def list_prompts(self) -> List[str]:
        if not self._path.exists():
            raise RuntimeError(f"System prompts file not found: {self._path}")
        prompts: List[str] = []
        for line in self._path.read_text(encoding="ascii").splitlines():
            line = line.strip()
            if line.startswith("## "):
                prompts.append(line.replace("## ", "").strip())
        if not prompts:
            raise RuntimeError(f"No prompt roles found in {self._path}")
        return prompts

    def get_prompt(self, role: str) -> str:
        if not self._path.exists():
            raise RuntimeError(f"System prompts file not found: {self._path}")
        content = self._path.read_text(encoding="ascii")
        marker = f"## {role}"
        lines = content.splitlines()
        start = None
        for idx, line in enumerate(lines):
            if line.strip() == marker:
                start = idx + 1
                break
        if start is None:
            raise ValueError(f"Prompt role not found: {role}")
        collected: List[str] = []
        for line in lines[start:]:
            if line.strip().startswith("## "):
                break
            collected.append(line)
        return "\n".join(collected).strip()


class MCPServer:
    def __init__(
        self, neo4j_uri: str, neo4j_user: str, neo4j_password: str, qdrant_url: str, server_name: str
    ) -> None:
        self._driver = GraphDatabase.driver(neo4j_uri, auth=(neo4j_user, neo4j_password))
        self._qdrant = QdrantClient(url=qdrant_url)
        self._server_name = server_name
        self._prompts = PromptStore(SYSTEM_PROMPTS_PATH)

    def close(self) -> None:
        self._driver.close()

    def handle(self, request: Dict[str, Any]) -> Dict[str, Any]:
        method = request.get("method")
        params = request.get("params") or {}
        if method == "initialize":
            return self._initialize()
        if method == "initialized":
            return {}
        if method in ("ping", "server/ping"):
            return {}
        if method in ("mcp/server/list", "server/list"):
            return {"servers": [{"name": self._server_name, "version": "0.1"}]}
        if method == "list_tools":
            return {
                "server_name": self._server_name,
                "tools": self._tool_descriptors(),
            }
        if method in ("tools/list", "tools.list"):
            return {"tools": self._tool_descriptors()}
        if method in ("tools/call", "tools.call"):
            tool_name = params.get("name")
            arguments = params.get("arguments") or {}
            if not tool_name:
                raise ValueError("tools/call requires 'name'")
            result = self._call_tool(tool_name, arguments)
            return {"content": [{"type": "text", "text": json.dumps(result)}]}
        if method in ("resources/list", "resources.list"):
            return {"resources": []}
        if method in ("resources/read", "resources.read"):
            raise ValueError("resources/read is not implemented")
        if method in ("neo4j_query", "neo4j/query"):
            return self._neo4j_query(params)
        if method in ("qdrant_scroll", "qdrant/scroll"):
            return self._qdrant_scroll(params)
        if method in ("qdrant_search", "qdrant/search"):
            return self._qdrant_search(params)
        if method in ("list_prompts", "prompts/list", "prompts.list"):
            return {"prompts": self._prompts.list_prompts()}
        if method in ("get_prompt", "prompts/get", "prompts.get"):
            name = params.get("name") or params.get("role")
            if not name:
                raise ValueError("get_prompt requires 'name' or 'role'")
            if method in ("get_prompt",):
                return {"role": name, "content": self._prompts.get_prompt(name)}
            return {"prompt": {"name": name, "content": self._prompts.get_prompt(name)}}
        raise ValueError(f"Unknown method: {method}")

    def _initialize(self) -> Dict[str, Any]:
        return {
            "protocolVersion": "2024-11-05",
            "serverInfo": {"name": self._server_name, "version": "0.1"},
            "capabilities": {
                "tools": {},
                "prompts": {},
            },
        }

    def _tool_descriptors(self) -> List[Dict[str, Any]]:
        tools = [
            {
                "name": "server_ping",
                "description": "Return a basic health response from the MCP server.",
                "inputSchema": {"type": "object", "properties": {}},
            },
            {
                "name": "neo4j_query",
                "description": "Run a Cypher query and return records.",
                "inputSchema": {
                    "type": "object",
                    "properties": {
                        "cypher": {"type": "string"},
                        "params": {"type": "object"},
                    },
                    "required": ["cypher"],
                },
            },
            {
                "name": "qdrant_scroll",
                "description": "Scroll Qdrant points with optional filter.",
                "inputSchema": {
                    "type": "object",
                    "properties": {
                        "collection": {"type": "string"},
                        "limit": {"type": "integer"},
                        "offset": {},
                        "filter": {},
                    },
                    "required": ["collection"],
                },
            },
            {
                "name": "qdrant_search",
                "description": "Search Qdrant by vector with optional filter.",
                "inputSchema": {
                    "type": "object",
                    "properties": {
                        "collection": {"type": "string"},
                        "vector": {"type": "array", "items": {"type": "number"}},
                        "limit": {"type": "integer"},
                        "filter": {},
                    },
                    "required": ["collection", "vector"],
                },
            },
        ]
        for tool in tools:
            tool["parameters"] = tool["inputSchema"]
        return tools

    def _call_tool(self, name: str, arguments: Dict[str, Any]) -> Dict[str, Any]:
        if name == "server_ping":
            return {"status": "ok", "server": self._server_name}
        if name == "neo4j_query":
            return self._neo4j_query(arguments)
        if name == "qdrant_scroll":
            return self._qdrant_scroll(arguments)
        if name == "qdrant_search":
            return self._qdrant_search(arguments)
        raise ValueError(f"Unknown tool: {name}")

    def _neo4j_query(self, params: Dict[str, Any]) -> Dict[str, Any]:
        cypher = params.get("cypher")
        if not cypher:
            raise ValueError("neo4j_query requires 'cypher'")
        query_params = params.get("params") or {}
        with self._driver.session() as session:
            records = session.run(cypher, **query_params).data()
        return {"records": _to_jsonable(records)}

    def _qdrant_scroll(self, params: Dict[str, Any]) -> Dict[str, Any]:
        collection = params.get("collection")
        if not collection:
            raise ValueError("qdrant_scroll requires 'collection'")
        limit = int(params.get("limit") or 50)
        offset = params.get("offset")
        qfilter = params.get("filter")
        points, next_offset = self._qdrant.scroll(
            collection_name=collection,
            limit=limit,
            offset=offset,
            with_payload=True,
            with_vectors=False,
            scroll_filter=qfilter,
        )
        items = [{"id": p.id, "payload": p.payload} for p in points]
        return {"points": items, "next_offset": next_offset}

    def _qdrant_search(self, params: Dict[str, Any]) -> Dict[str, Any]:
        collection = params.get("collection")
        vector = params.get("vector")
        if not collection or vector is None:
            raise ValueError("qdrant_search requires 'collection' and 'vector'")
        limit = int(params.get("limit") or 10)
        qfilter = params.get("filter")
        hits = self._qdrant.search(
            collection_name=collection,
            query_vector=vector,
            limit=limit,
            with_payload=True,
            query_filter=qfilter,
        )
        items = [{"id": h.id, "score": h.score, "payload": _to_jsonable(h.payload)} for h in hits]
        return {"points": items}


def _to_jsonable(value: Any) -> Any:
    if isinstance(value, Node):
        return {
            "id": value.id,
            "labels": list(value.labels),
            "properties": _to_jsonable(dict(value)),
        }
    if isinstance(value, Relationship):
        return {
            "id": value.id,
            "type": value.type,
            "start_node_id": value.start_node.id,
            "end_node_id": value.end_node.id,
            "properties": _to_jsonable(dict(value)),
        }
    if isinstance(value, Neo4jPath):
        return {
            "nodes": [_to_jsonable(node) for node in value.nodes],
            "relationships": [_to_jsonable(rel) for rel in value.relationships],
        }
    if isinstance(value, dict):
        return {key: _to_jsonable(val) for key, val in value.items()}
    if isinstance(value, (list, tuple)):
        return [_to_jsonable(item) for item in value]
    return value


def _jsonrpc_response(request_id: Any, result: Optional[Dict[str, Any]] = None, error: Optional[str] = None) -> Dict[str, Any]:
    if error:
        return {"jsonrpc": "2.0", "id": request_id, "error": {"code": -32000, "message": error}}
    return {"jsonrpc": "2.0", "id": request_id, "result": result}


def serve_stdio(server: MCPServer) -> None:
    for line in sys.stdin:
        line = line.strip()
        if not line:
            continue
        try:
            request = json.loads(line)
            request_id = request.get("id")
            result = server.handle(request)
            response = _jsonrpc_response(request_id, result=result)
        except Exception as exc:
            response = _jsonrpc_response(request.get("id"), error=str(exc))
        sys.stdout.write(json.dumps(response) + "\n")
        sys.stdout.flush()


class _MCPHandler(BaseHTTPRequestHandler):
    server_version = "MCPServer/0.1"

    def do_GET(self) -> None:
        if not hasattr(self.server, "sse_clients_add"):
            self.send_error(500, "SSE not initialized")
            return
        self.send_response(200)
        self.send_header("Content-Type", "text/event-stream")
        self.send_header("Cache-Control", "no-cache")
        self.send_header("Connection", "keep-alive")
        self.end_headers()
        client = self.wfile
        self.server.sse_clients_add(client)  # type: ignore[attr-defined]
        try:
            while True:
                self.server.sse_send_keepalive(client)  # type: ignore[attr-defined]
                time.sleep(15)
        except Exception:
            return
        finally:
            self.server.sse_clients_remove(client)  # type: ignore[attr-defined]

    def do_POST(self) -> None:
        content_length = int(self.headers.get("Content-Length") or 0)
        body = self.rfile.read(content_length)
        try:
            request = json.loads(body.decode("utf-8"))
            request_id = request.get("id")
            result = self.server.mcp.handle(request)  # type: ignore[attr-defined]
            response = _jsonrpc_response(request_id, result=result)
            status = 200
        except Exception as exc:
            response = _jsonrpc_response(request.get("id") if isinstance(request, dict) else None, error=str(exc))
            status = 200
        if request_id is None:
            self.send_response(204)
            self.end_headers()
            return
        payload = json.dumps(response).encode("utf-8")
        self.server.sse_broadcast(payload)  # type: ignore[attr-defined]
        self.send_response(status)
        self.send_header("Content-Type", "application/json")
        self.send_header("Content-Length", str(len(payload)))
        self.end_headers()
        self.wfile.write(payload)

    def log_message(self, format: str, *args: Any) -> None:
        return


class _MCPHttpServer(ThreadingHTTPServer):
    def __init__(self, server_address: Tuple[str, int], handler_cls: type[BaseHTTPRequestHandler], mcp: MCPServer) -> None:
        super().__init__(server_address, handler_cls)
        self.mcp = mcp
        self._sse_lock = threading.Lock()
        self._sse_clients: List[Any] = []

    def sse_clients_add(self, client: Any) -> None:
        with self._sse_lock:
            self._sse_clients.append(client)

    def sse_clients_remove(self, client: Any) -> None:
        with self._sse_lock:
            if client in self._sse_clients:
                self._sse_clients.remove(client)

    def sse_send_keepalive(self, client: Any) -> None:
        with self._sse_lock:
            try:
                client.write(b": keepalive\n\n")
                client.flush()
            except Exception:
                pass

    def sse_broadcast(self, payload: bytes) -> None:
        message = b"event: message\ndata: " + payload + b"\n\n"
        with self._sse_lock:
            for client in list(self._sse_clients):
                try:
                    client.write(message)
                    client.flush()
                except Exception:
                    self._sse_clients.remove(client)


def serve_http(server: MCPServer, host: str, port: int) -> None:
    httpd = _MCPHttpServer((host, port), _MCPHandler, server)
    httpd.serve_forever()


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--transport", choices=["stdio", "http"], default="stdio")
    parser.add_argument("--host", default="127.0.0.1")
    parser.add_argument("--port", type=int, default=8765)
    parser.add_argument("--neo4j-uri", default="bolt://localhost:7687")
    parser.add_argument("--neo4j-user", default="neo4j")
    parser.add_argument("--neo4j-password", default="neo4j12#456")
    parser.add_argument("--qdrant-url", default="http://localhost:6333")
    parser.add_argument("--server-name", default="graph-vector-mcp")
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")
    server = MCPServer(args.neo4j_uri, args.neo4j_user, args.neo4j_password, args.qdrant_url, args.server_name)
    logging.info("MCP server '%s' starting transport=%s", args.server_name, args.transport)
    try:
        if args.transport == "stdio":
            serve_stdio(server)
        else:
            serve_http(server, args.host, args.port)
    finally:
        server.close()


if __name__ == "__main__":
    main()
