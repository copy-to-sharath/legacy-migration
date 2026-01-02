import json
import re
import sys
from collections import Counter
from pathlib import Path
from typing import Dict, List

ROOT = Path(r"c:\Users\shara\code\migration\workspace")
sys.path.insert(0, str(ROOT))

from mcp_server.mcp_client import MCPClient


BOUNDED_CONTEXTS_PATH = ROOT / "deliverables" / "bounded-contexts.md"
OUTPUT_PATH = ROOT / "state" / "context_keywords.json"
STOPWORDS = {
    "admin",
    "module",
    "modules",
    "page",
    "pages",
    "home",
    "details",
    "add",
    "edit",
    "list",
    "view",
    "default",
    "settings",
    "manager",
    "service",
    "helper",
    "provider",
    "control",
    "controls",
}


def parse_contexts() -> List[str]:
    if not BOUNDED_CONTEXTS_PATH.exists():
        raise RuntimeError(f"Bounded contexts file not found: {BOUNDED_CONTEXTS_PATH}")
    contexts: List[str] = []
    for line in BOUNDED_CONTEXTS_PATH.read_text(encoding="ascii").splitlines():
        if line.startswith("### "):
            contexts.append(line.replace("### ", "").strip())
    if not contexts:
        raise RuntimeError("No contexts found in bounded-contexts.md")
    return contexts


def tokenize(name: str) -> List[str]:
    base = re.sub(r"\.[a-zA-Z0-9]+$", "", name)
    tokens = re.split(r"[^a-zA-Z0-9]+", base)
    return [t.lower() for t in tokens if len(t) >= 3]


def build_keywords(client: MCPClient, contexts: List[str]) -> Dict[str, List[str]]:
    mapping: Dict[str, List[str]] = {}
    for context in contexts:
        cypher = (
            "MATCH (n:Node {type:'File'}) "
            "WHERE toLower(n.name) CONTAINS toLower($key) "
            "RETURN n.name AS name "
            "ORDER BY n.name LIMIT 300"
        )
        result = client.call("neo4j_query", {"cypher": cypher, "params": {"key": context}})
        counter: Counter[str] = Counter()
        for row in result.get("records", []):
            for token in tokenize(row["name"]):
                if token in STOPWORDS:
                    continue
                counter[token] += 1
        context_tokens = tokenize(context)
        for token in context_tokens:
            counter[token] += 10
        keywords = [token for token, _ in counter.most_common(12)]
        mapping[context] = keywords
    return mapping


def main() -> int:
    contexts = parse_contexts()
    server_path = ROOT / "mcp_server" / "mcp_server.py"
    client = MCPClient(
        transport="stdio",
        server_cmd=[
            sys.executable,
            "-u",
            str(server_path),
            "--transport",
            "stdio",
            "--server-name",
            "graph-vector-mcp",
        ],
    )
    try:
        mapping = build_keywords(client, contexts)
    finally:
        client.close()

    OUTPUT_PATH.parent.mkdir(parents=True, exist_ok=True)
    OUTPUT_PATH.write_text(json.dumps(mapping, indent=2), encoding="ascii")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
