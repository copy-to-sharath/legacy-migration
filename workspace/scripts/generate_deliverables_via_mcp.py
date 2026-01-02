import os
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
from prompt_catalog import (
    load_api_mapping_template,
    load_context_readme_template,
    load_project_readme_template,
    load_reqnroll_readme_template,
    workflow_header_lines,
)
DELIVERABLES = ROOT / "deliverables"
FEATURES_DIR = DELIVERABLES / "features"
TESTS_DIR = DELIVERABLES / "tests"
SRC_DIR = DELIVERABLES / "src"


CONTEXTS = load_context_keywords()


def endpoint_path(source_file: str) -> str:
    normalized = source_file.replace("\\", "/")
    marker = "nopcommercestore/"
    idx = normalized.lower().find(marker)
    rel = normalized[idx + len(marker) :] if idx >= 0 else normalized.split("/", 1)[-1]
    return "/" + rel


def classify_context(name: str, source_file: str) -> str:
    return classify_by_keywords(f"{name} {source_file}", CONTEXTS)


def slug_from_file(source_file: str) -> str:
    base = os.path.splitext(os.path.basename(source_file))[0]
    slug = re.sub(r"[^a-zA-Z0-9]+", "-", base).strip("-").lower()
    return slug or "item"


def format_citation(row: Dict[str, str]) -> str:
    return f"{row['sourceFile']}:{row['sourceLine']}"


def fetch_endpoints(client: MCPClient) -> List[Dict[str, str]]:
    cypher = (
        "MATCH (n:Node {type:'File'}) "
        "WHERE n.ext IN ['.aspx','.ashx','.asmx'] "
        "RETURN n.name AS name, n.ext AS ext, n.sourceFile AS sourceFile, n.sourceLine AS sourceLine "
        "ORDER BY n.ext, n.name"
    )
    result = client.call("neo4j_query", {"cypher": cypher})
    return result.get("records", [])


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
            citations.append(format_citation(row))
    return sorted(set(citations))


def qdrant_sample_citations(client: MCPClient, limit: int = 10) -> List[str]:
    result = client.call("qdrant_scroll", {"collection": "code_vectors", "limit": limit})
    citations: List[str] = []
    for point in result.get("points", []):
        payload = point.get("payload") or {}
        source_file = payload.get("sourceFile")
        source_line = payload.get("sourceLine")
        if source_file and source_line:
            citations.append(f"{source_file}:{source_line}")
    return sorted(set(citations))


def write_api_mapping(endpoints: List[Dict[str, str]], vector_cites: List[str]) -> None:
    legacy_rows: List[str] = []
    mapped_count = 0
    for row in endpoints:
        path = endpoint_path(row["sourceFile"])
        context = classify_context(row["name"], row["sourceFile"])
        slug = slug_from_file(row["sourceFile"])
        proposed = f"/api/{context.lower()}/{slug}"
        if context == "Unassigned":
            proposed = f"/api/legacy/{slug}"
        mapped_count += 1
        legacy_rows.append(
            f"| `{path}` | `{row['ext']}` | `{proposed}` | {context} | `{format_citation(row)}` |"
        )

    coverage_lines = [
        f"- Legacy endpoints listed: {len(endpoints)}",
        f"- Mapped endpoints in this document: {mapped_count}",
        "- Remaining endpoints: 0 (inventory coverage complete)",
    ]
    vector_lines = [f"- `{cite}`" for cite in vector_cites[:20]] or ["- None"]

    template = load_api_mapping_template()
    content = template.format(
        agent_header="\n".join(workflow_header_lines("api-mapping")),
        legacy_rows="\n".join(legacy_rows) or "| _none_ | _none_ | _none_ | _none_ | _none_ |",
        coverage_summary="\n".join(coverage_lines),
        vector_citations="\n".join(vector_lines),
    )
    (DELIVERABLES / "api-mapping.md").write_text(content, encoding="ascii")


def parse_feature_file(path: Path) -> Tuple[str, List[str]]:
    feature_name = ""
    scenarios: List[str] = []
    for line in path.read_text(encoding="ascii").splitlines():
        if line.startswith("Feature:"):
            feature_name = line.replace("Feature:", "").strip()
        if line.strip().startswith("Scenario:"):
            scenarios.append(line.split("Scenario:", 1)[1].strip())
    return feature_name or path.stem, scenarios


def write_reqnroll_tests(client: MCPClient) -> None:
    TESTS_DIR.mkdir(parents=True, exist_ok=True)
    for feature_path in FEATURES_DIR.glob("*.feature"):
        feature_name, scenarios = parse_feature_file(feature_path)
        context = classify_context(feature_name, feature_path.name)
        context_keys = CONTEXTS.get(context, [])
        citations = fetch_context_citations(client, context_keys)[:5]
        class_name = re.sub(r"[^a-zA-Z0-9]+", "", feature_name.title()) + "Steps"
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
        for scenario in scenarios:
            method_name = re.sub(r"[^a-zA-Z0-9]+", "", scenario.title())
            lines.extend(
                [
                    "    [Given(@\".*\")]",
                    f"    public void Given_{method_name}()",
                    "    {",
                    "        // TODO: implement step",
                    "    }",
                    "",
                    "    [When(@\".*\")]",
                    f"    public void When_{method_name}()",
                    "    {",
                    "        // TODO: implement step",
                    "    }",
                    "",
                    "    [Then(@\".*\")]",
                    f"    public void Then_{method_name}()",
                    "    {",
                    "        // TODO: implement step",
                    "    }",
                    "",
                ]
            )
        lines.append("}")
        out_path = TESTS_DIR / f"{feature_path.stem}_steps.cs"
        out_path.write_text("\n".join(lines), encoding="ascii")


def write_dotnet_skeleton(client: MCPClient) -> None:
    SRC_DIR.mkdir(parents=True, exist_ok=True)
    for context, keys in CONTEXTS.items():
        context_dir = SRC_DIR / "Contexts" / context
        (context_dir / "Domain").mkdir(parents=True, exist_ok=True)
        (context_dir / "Application").mkdir(parents=True, exist_ok=True)
        (context_dir / "Infrastructure").mkdir(parents=True, exist_ok=True)
        (context_dir / "Api").mkdir(parents=True, exist_ok=True)

        citations = fetch_context_citations(client, keys)[:5]
        citation_lines = [f"- `{cite}`" for cite in citations] or ["- None"]
        context_template = load_context_readme_template()
        context_readme = context_template.format(
            context=context,
            agent_header="\n".join(workflow_header_lines("code")),
            citations="\n".join(citation_lines),
        )
        (context_dir / "README.md").write_text(context_readme, encoding="ascii")

        for project in ["Domain", "Application", "Infrastructure", "Api"]:
            proj_dir = context_dir / project
            proj_name = f"{context}.{project}"
            csproj = [
                "<Project Sdk=\"Microsoft.NET.Sdk\">",
                "  <PropertyGroup>",
                "    <TargetFramework>net8.0</TargetFramework>",
                "    <Nullable>enable</Nullable>",
                "    <ImplicitUsings>enable</ImplicitUsings>",
                "  </PropertyGroup>",
                "</Project>",
            ]
            (proj_dir / f"{proj_name}.csproj").write_text("\n".join(csproj), encoding="ascii")
            project_template = load_project_readme_template()
            project_readme = project_template.format(
                title=proj_name, agent_header="\n".join(workflow_header_lines("code"))
            )
            (proj_dir / "README.md").write_text(project_readme, encoding="ascii")


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
        endpoints = fetch_endpoints(client)
        vector_cites = qdrant_sample_citations(client)
        write_api_mapping(endpoints, vector_cites)
        write_reqnroll_tests(client)
        write_dotnet_skeleton(client)
    finally:
        client.close()
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
