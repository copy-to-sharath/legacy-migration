import re
import sys
from pathlib import Path
from typing import Dict, List, Tuple

ROOT = Path(r"c:\Users\shara\code\migration\workspace")
sys.path.insert(0, str(ROOT))
sys.path.insert(0, str(ROOT / "scripts"))

from mcp_server.mcp_client import MCPClient
from context_keywords import classify_context as classify_by_keywords
from context_keywords import load_context_keywords
from prompt_catalog import workflow_header_lines

DELIVERABLES = ROOT / "deliverables"
FEATURES_DIR = DELIVERABLES / "features"
TESTS_DIR = DELIVERABLES / "tests"

CONTEXT_KEYWORDS = load_context_keywords()


def parse_feature(path: Path) -> Tuple[str, List[Tuple[str, str, str]]]:
    feature_name = path.stem
    scenarios: List[Tuple[str, str, str]] = []
    current = ""
    for line in path.read_text(encoding="ascii").splitlines():
        if line.startswith("Feature:"):
            feature_name = line.split("Feature:", 1)[1].strip()
        if line.strip().startswith("Scenario:"):
            current = line.split("Scenario:", 1)[1].strip()
        if line.strip().startswith("Given "):
            scenarios.append((current, "Given", line.strip()[6:]))
        if line.strip().startswith("When "):
            scenarios.append((current, "When", line.strip()[5:]))
        if line.strip().startswith("Then "):
            scenarios.append((current, "Then", line.strip()[5:]))
    return feature_name, scenarios


def fetch_context_citations(client: MCPClient, keywords: List[str]) -> List[str]:
    citations: List[str] = []
    for key in keywords:
        cypher = (
            "MATCH (n:Node {type:'File'}) "
            "WHERE toLower(n.name) CONTAINS toLower($key) "
            "RETURN n.sourceFile AS sourceFile, n.sourceLine AS sourceLine "
            "ORDER BY n.name LIMIT 3"
        )
        result = client.call("neo4j_query", {"cypher": cypher, "params": {"key": key}})
        for row in result.get("records", []):
            citations.append(f"{row['sourceFile']}:{row['sourceLine']}")
    return sorted(set(citations))


def slug(text: str) -> str:
    return re.sub(r"[^a-zA-Z0-9]+", "", text.title())


def generate_steps(client: MCPClient) -> None:
    for feature_path in FEATURES_DIR.glob("*.feature"):
        feature_name, steps = parse_feature(feature_path)
        context = classify_by_keywords(feature_name, CONTEXT_KEYWORDS)
        citations = fetch_context_citations(client, CONTEXT_KEYWORDS.get(context, []))[:5]

        class_name = f"{slug(feature_name)}Steps"
        lines: List[str] = [
            *workflow_header_lines("tests", comment_prefix="//"),
            "// Citations:",
        ]
        for cite in citations:
            lines.append(f"// - {cite}")
        lines.extend(
            [
                "using Reqnroll;",
                "",
                "namespace Migration.Tests;",
                "",
                "[Binding]",
                f"public sealed class {class_name}",
                "{",
            ]
        )
        for scenario, kind, text in steps:
            method_name = f"{kind}_{slug(scenario)}_{slug(text)}"
            escaped = text.replace("\"", "\"\"")
            lines.extend(
                [
                    f"    [{kind}(@\"{escaped}\")]",
                    f"    public void {method_name}()",
                    "    {",
                    "        // TODO: implement step",
                    "    }",
                    "",
                ]
            )
        lines.append("}")
        out_path = TESTS_DIR / f"{feature_path.stem}_steps.cs"
        out_path.write_text("\n".join(lines), encoding="ascii")


def main() -> int:
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
        generate_steps(client)
    finally:
        client.close()
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
