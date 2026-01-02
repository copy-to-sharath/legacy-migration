import re
import sys
from pathlib import Path
from typing import Dict, List

ROOT = Path(r"c:\Users\shara\code\migration\workspace")
sys.path.insert(0, str(ROOT))
sys.path.insert(0, str(ROOT / "scripts"))

from mcp_server.mcp_client import MCPClient
from context_keywords import load_context_keywords
from prompt_catalog import load_brd_template, workflow_header_lines

DELIVERABLES = ROOT / "deliverables"
FEATURES_DIR = DELIVERABLES / "features"
BOUNDED_CONTEXTS_PATH = DELIVERABLES / "bounded-contexts.md"


def slug(text: str) -> str:
    return re.sub(r"[^a-zA-Z0-9]+", "-", text).strip("-").lower()


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


def build_keyword_clause(keywords: List[str]) -> str:
    clauses = []
    for idx, _ in enumerate(keywords):
        clauses.append(f"toLower(n.name) CONTAINS toLower($k{idx})")
    return " OR ".join(clauses) if clauses else "false"


def fetch_samples(client: MCPClient, keywords: List[str], limit: int = 5) -> List[Dict[str, str]]:
    samples: List[Dict[str, str]] = []
    for key in keywords:
        cypher = (
            "MATCH (n:Node {type:'File'}) "
            "WHERE toLower(n.name) CONTAINS toLower($key) "
            "RETURN n.name AS name, n.sourceFile AS sourceFile, n.sourceLine AS sourceLine "
            "ORDER BY n.name LIMIT $limit"
        )
        result = client.call("neo4j_query", {"cypher": cypher, "params": {"key": key, "limit": limit}})
        samples.extend(result.get("records", []))
    return samples


def format_citation(row: Dict[str, str]) -> str:
    return f"{row['sourceFile']}:{row['sourceLine']}"


def fetch_endpoints(client: MCPClient, keywords: List[str], limit: int = 10) -> List[Dict[str, str]]:
    clause = build_keyword_clause(keywords)
    params = {f"k{idx}": value for idx, value in enumerate(keywords)}
    cypher = (
        "MATCH (n:Node {type:'File'}) "
        "WHERE n.ext IN ['.aspx','.ashx','.asmx'] AND (" + clause + ") "
        "RETURN n.name AS name, n.ext AS ext, n.sourceFile AS sourceFile, n.sourceLine AS sourceLine "
        "ORDER BY n.name LIMIT $limit"
    )
    params["limit"] = limit
    result = client.call("neo4j_query", {"cypher": cypher, "params": params})
    return result.get("records", [])


def build_brd(client: MCPClient, keywords: Dict[str, List[str]], contexts: List[str]) -> None:
    total_contexts = len(contexts)
    in_scope_lines: List[str] = []
    for context in contexts:
        keys = keywords.get(context, [])
        samples = fetch_samples(client, keys, limit=2)
        if not samples:
            continue
        in_scope_lines.append(f"- {context}:")
        for row in samples[:3]:
            in_scope_lines.append(f"  - `{format_citation(row)}`")

    fr_lines: List[str] = []
    fr_index = 1
    for context in contexts:
        keys = keywords.get(context, [])
        samples = fetch_samples(client, keys, limit=3)
        if not samples:
            continue
        fr_lines.append(f"FR-{fr_index} {context} workflows")
        fr_lines.append(f"- The system shall support {context.lower()} workflows.")
        fr_lines.append("  - Evidence:")
        for row in samples[:3]:
            fr_lines.append(f"    - `{format_citation(row)}`")
        fr_lines.append("")
        fr_index += 1

    template = load_brd_template()
    content = template.format(
        agent_header="\n".join(workflow_header_lines("brd")),
        total_contexts=total_contexts,
        in_scope_modules="\n".join(in_scope_lines),
        functional_requirements="\n".join(fr_lines),
    )
    lines = content.splitlines()
    (DELIVERABLES / "brd.md").write_text("\n".join(lines), encoding="ascii")


def build_features(client: MCPClient, keywords: Dict[str, List[str]], contexts: List[str]) -> None:
    FEATURES_DIR.mkdir(parents=True, exist_ok=True)
    for context in contexts:
        context_keys = keywords.get(context, [])
        endpoints = fetch_endpoints(client, context_keys, limit=5)
        filename = f"{slug(context)}.feature"
        title = f"{context} workflows"
        lines: List[str] = [
            *workflow_header_lines("gherkin", comment_prefix="#"),
            f"Feature: {title}",
        ]
        for row in endpoints[:2]:
            lines.append(f"  # cite: {format_citation(row)}")
        lines.append("")
        if not endpoints:
            safe_context = context.lower()
            lines.extend(
                [
                    f"  Scenario: General flow for {context}",
                    f"    Given a valid {safe_context} request exists",
                    f"    When the {safe_context} request is processed",
                    f"    Then the {safe_context} response is returned",
                ]
            )
        else:
            for row in endpoints:
                endpoint_name = row["name"]
                endpoint_path = row["sourceFile"].replace("\\", "/").split("nopCommerceStore/")[-1]
                lines.extend(
                    [
                        f"  Scenario: Access {endpoint_name}",
                        f"    Given endpoint \"{endpoint_path}\" is available",
                        f"    When a \"{row['ext']}\" request is issued to \"{endpoint_path}\"",
                        f"    Then the system responds for \"{endpoint_path}\"",
                        "",
                    ]
                )
        (FEATURES_DIR / filename).write_text("\n".join(lines), encoding="ascii")


def main() -> int:
    keywords = load_context_keywords()
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
        build_brd(client, keywords, contexts)
        build_features(client, keywords, contexts)
    finally:
        client.close()
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
