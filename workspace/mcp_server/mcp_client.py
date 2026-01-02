import json
import subprocess
import sys
from typing import Any, Dict, Optional

import requests


class MCPClient:
    def __init__(self, transport: str = "stdio", server_cmd: Optional[list[str]] = None, http_url: str = "") -> None:
        self.transport = transport
        self.http_url = http_url
        self._proc: Optional[subprocess.Popen[str]] = None
        self._next_id = 1

        if transport == "stdio":
            if not server_cmd:
                raise ValueError("server_cmd is required for stdio transport")
            self._proc = subprocess.Popen(
                server_cmd,
                stdin=subprocess.PIPE,
                stdout=subprocess.PIPE,
                stderr=subprocess.PIPE,
                text=True,
                bufsize=1,
            )
        elif transport == "http":
            if not http_url:
                raise ValueError("http_url is required for http transport")
        else:
            raise ValueError("transport must be 'stdio' or 'http'")

    def close(self) -> None:
        if self._proc and self._proc.poll() is None:
            self._proc.terminate()
            self._proc.wait(timeout=5)

    def call(self, method: str, params: Optional[Dict[str, Any]] = None) -> Dict[str, Any]:
        request = {"jsonrpc": "2.0", "id": self._next_id, "method": method, "params": params or {}}
        self._next_id += 1

        if self.transport == "http":
            response = requests.post(self.http_url, json=request, timeout=30)
            response.raise_for_status()
            payload = response.json()
        else:
            if not self._proc or not self._proc.stdin or not self._proc.stdout:
                raise RuntimeError("MCP stdio process not initialized")
            self._proc.stdin.write(json.dumps(request) + "\n")
            self._proc.stdin.flush()
            line = self._proc.stdout.readline()
            if not line:
                raise RuntimeError("MCP stdio server closed unexpectedly")
            payload = json.loads(line)

        if "error" in payload:
            raise RuntimeError(payload["error"].get("message", "MCP error"))
        return payload.get("result") or {}


def main() -> int:
    client = MCPClient(
        transport="stdio",
        server_cmd=[sys.executable, "-u", "mcp_server.py", "--transport", "stdio"],
    )
    try:
        tools = client.call("list_tools")
        print(tools)
    finally:
        client.close()
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
