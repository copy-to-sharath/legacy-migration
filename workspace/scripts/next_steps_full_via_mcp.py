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
from prompt_catalog import load_api_mapping_template, workflow_header_lines

DELIVERABLES = ROOT / "deliverables"
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


def write_api_mapping(endpoints: List[Dict[str, str]], vector_cites: List[str]) -> List[Dict[str, str]]:
    legacy_rows: List[str] = []
    mapped: List[Dict[str, str]] = []
    legacy_count = 0
    for row in endpoints:
        path = endpoint_path(row["sourceFile"])
        context = classify_context(row["name"], row["sourceFile"])
        slug = slug_from_file(row["sourceFile"])
        proposed = f"/api/{context.lower()}/{slug}"
        if context == "Legacy":
            legacy_count += 1
        mapped.append(
            {
                "path": path,
                "ext": row["ext"],
                "proposed": proposed,
                "context": context,
                "citation": format_citation(row),
            }
        )
        legacy_rows.append(
            f"| `{path}` | `{row['ext']}` | `{proposed}` | {context} | `{format_citation(row)}` |"
        )

    coverage_lines = [
        f"- Legacy endpoints listed: {len(endpoints)}",
        f"- Mapped endpoints in this document: {len(endpoints)}",
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
    return mapped


def ensure_api_project(context: str) -> Path:
    api_dir = SRC_DIR / "Contexts" / context / "Api"
    api_dir.mkdir(parents=True, exist_ok=True)
    csproj = api_dir / f"{context}.Api.csproj"
    if csproj.exists():
        text = csproj.read_text(encoding="ascii")
        if "Microsoft.NET.Sdk.Web" not in text:
            text = text.replace("Microsoft.NET.Sdk", "Microsoft.NET.Sdk.Web")
            csproj.write_text(text, encoding="ascii")
    else:
        csproj.write_text(
            "\n".join(
                [
                    "<Project Sdk=\"Microsoft.NET.Sdk.Web\">",
                    "  <PropertyGroup>",
                    "    <TargetFramework>net8.0</TargetFramework>",
                    "    <Nullable>enable</Nullable>",
                    "    <ImplicitUsings>enable</ImplicitUsings>",
                    "  </PropertyGroup>",
                    "</Project>",
                ]
            ),
            encoding="ascii",
        )

    program = api_dir / "Program.cs"
    if not program.exists():
        program.write_text(
            "\n".join(
                [
                    "var builder = WebApplication.CreateBuilder(args);",
                    "builder.Services.AddControllers();",
                    "var app = builder.Build();",
                    "app.MapControllers();",
                    "app.Run();",
                ]
            ),
            encoding="ascii",
        )
    return api_dir


def write_controllers(mapped: List[Dict[str, str]]) -> None:
    grouped: Dict[str, List[Dict[str, str]]] = {}
    for item in mapped:
        grouped.setdefault(item["context"], []).append(item)

    for context, items in grouped.items():
        api_dir = ensure_api_project(context)
        models_dir = api_dir / "Models"
        models_dir.mkdir(parents=True, exist_ok=True)
        models_path = models_dir / "EndpointInfo.cs"
        if not models_path.exists():
            models_path.write_text(
                "\n".join(
                    [
                        f"namespace Migration.{context}.Api.Models;",
                        "",
                        "public sealed record EndpointInfo(",
                        "    string LegacyEndpoint,",
                        "    string Context,",
                        "    string Method,",
                        "    string Evidence",
                        ");",
                    ]
                ),
                encoding="ascii",
            )
        controller_name = "Legacy" if context == "Legacy" else context
        file_path = api_dir / "Controllers" / f"{controller_name}Controller.cs"
        file_path.parent.mkdir(parents=True, exist_ok=True)

        lines: List[str] = [
            *workflow_header_lines("code", comment_prefix="//"),
            "using Microsoft.AspNetCore.Mvc;",
            f"using Migration.{context}.Api.Models;",
            "",
            f"namespace Migration.{context}.Api.Controllers;",
            "",
            "[ApiController]",
            f"[Route(\"api/{context.lower()}\")]",
            f"public sealed class {controller_name}Controller : ControllerBase",
            "{",
        ]
        for item in items:
            method_name = re.sub(r"[^a-zA-Z0-9]+", "", item["proposed"].split("/")[-1].title())
            http_attr = "HttpGet"
            if item["ext"] == ".asmx":
                http_attr = "HttpPost"
            elif item["ext"] == ".ashx":
                http_attr = "HttpGet"
            lines.extend(
                [
                    f"    // Evidence: {item['citation']}",
                    f"    [{http_attr}(\"{item['proposed'].split('/api/')[1]}\")]",
                    f"    public IActionResult {method_name}()",
                    "    {",
                    "        var payload = new EndpointInfo(",
                    "            LegacyEndpoint: \"" + item["path"] + "\",",
                    "            Context: \"" + context + "\",",
                    "            Method: \"" + item["ext"] + "\",",
                    "            Evidence: \"" + item["citation"] + "\"",
                    "        );",
                    "        return Ok(payload);",
                    "    }",
                    "",
                ]
            )
        lines.append("}")
        file_path.write_text("\n".join(lines), encoding="ascii")


def run_tests() -> None:
    sln_path = SRC_DIR / "Migration.sln"
    subprocess.run(["dotnet", "test", str(sln_path)], cwd=SRC_DIR, check=False)


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
        mapped = write_api_mapping(endpoints, vector_cites)
    finally:
        client.close()

    write_controllers(mapped)
    run_tests()
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
