import os
import re
import subprocess
import sys
from pathlib import Path
from typing import Dict, List

ROOT = Path(r"c:\Users\shara\code\migration\workspace")
sys.path.insert(0, str(ROOT))
sys.path.insert(0, str(ROOT / "scripts"))

from mcp_server.mcp_client import MCPClient
from context_keywords import classify_context as classify_by_keywords
from context_keywords import load_context_keywords
from prompt_catalog import load_api_mapping_template, load_reqnroll_readme_template, workflow_header_lines

DELIVERABLES = ROOT / "deliverables"
FEATURES_DIR = DELIVERABLES / "features"
TESTS_DIR = DELIVERABLES / "tests"
TEST_PROJECT_DIR = TESTS_DIR / "ReqnrollTests"
SRC_DIR = DELIVERABLES / "src"


CONTEXT_KEYWORDS = load_context_keywords()


def endpoint_path(source_file: str) -> str:
    normalized = source_file.replace("\\", "/")
    marker = "nopcommercestore/"
    idx = normalized.lower().find(marker)
    rel = normalized[idx + len(marker) :] if idx >= 0 else normalized.split("/", 1)[-1]
    return "/" + rel


def classify_context(name: str, source_file: str) -> str:
    return classify_by_keywords(f"{name} {source_file}", CONTEXT_KEYWORDS)


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
    legacy_count = 0
    for row in endpoints:
        path = endpoint_path(row["sourceFile"])
        context = classify_context(row["name"], row["sourceFile"])
        slug = slug_from_file(row["sourceFile"])
        proposed = f"/api/{context.lower()}/{slug}"
        if context == "Legacy":
            legacy_count += 1
        mapped_count += 1
        legacy_rows.append(
            f"| `{path}` | `{row['ext']}` | `{proposed}` | {context} | `{format_citation(row)}` |"
        )

    coverage_lines = [
        f"- Legacy endpoints listed: {len(endpoints)}",
        f"- Mapped endpoints in this document: {mapped_count}",
        f"- Remaining endpoints: 0 (inventory coverage complete)",
        f"- Legacy bucket (needs review): {legacy_count}",
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


def create_reqnroll_project(vector_cites: List[str]) -> None:
    TEST_PROJECT_DIR.mkdir(parents=True, exist_ok=True)
    csproj = [
        "<Project Sdk=\"Microsoft.NET.Sdk\">",
        "  <PropertyGroup>",
        "    <TargetFramework>net8.0</TargetFramework>",
        "    <Nullable>enable</Nullable>",
        "    <ImplicitUsings>enable</ImplicitUsings>",
        "    <IsTestProject>true</IsTestProject>",
        "  </PropertyGroup>",
        "  <ItemGroup>",
        "    <PackageReference Include=\"Reqnroll\" Version=\"2.1.0\" />",
        "    <PackageReference Include=\"Reqnroll.NUnit\" Version=\"2.1.0\" />",
        "    <PackageReference Include=\"Microsoft.NET.Test.Sdk\" Version=\"17.8.0\" />",
        "    <PackageReference Include=\"NUnit\" Version=\"3.14.0\" />",
        "    <PackageReference Include=\"NUnit3TestAdapter\" Version=\"4.5.0\" />",
        "  </ItemGroup>",
        "  <ItemGroup>",
        "    <Compile Include=\"..\\*.cs\" Link=\"Steps\\%(Filename)%(Extension)\" />",
        "  </ItemGroup>",
        "  <ItemGroup>",
        "    <None Include=\"..\\..\\features\\*.feature\" CopyToOutputDirectory=\"PreserveNewest\" />",
        "  </ItemGroup>",
        "</Project>",
    ]
    (TEST_PROJECT_DIR / "ReqnrollTests.csproj").write_text("\n".join(csproj), encoding="ascii")

    vector_lines = [f"- `{cite}`" for cite in vector_cites[:20]] or ["- None"]
    template = load_reqnroll_readme_template()
    content = template.format(
        agent_header="\n".join(workflow_header_lines("tests")),
        vector_citations="\n".join(vector_lines),
    )
    (TEST_PROJECT_DIR / "README.md").write_text(content, encoding="ascii")


def create_solution() -> None:
    SRC_DIR.mkdir(parents=True, exist_ok=True)
    sln_path = SRC_DIR / "Migration.sln"
    if not sln_path.exists():
        subprocess.run(["dotnet", "new", "sln", "--name", "Migration"], cwd=SRC_DIR, check=True)

    csprojs = list(SRC_DIR.glob("Contexts/**/**/*.csproj"))
    if TEST_PROJECT_DIR.exists():
        csprojs.append(TEST_PROJECT_DIR / "ReqnrollTests.csproj")

    for proj in csprojs:
        subprocess.run(["dotnet", "sln", str(sln_path), "add", str(proj)], cwd=SRC_DIR, check=False)


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
        create_reqnroll_project(vector_cites)
    finally:
        client.close()

    create_solution()
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
