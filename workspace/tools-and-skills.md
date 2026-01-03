# Tools and Skills Usage

## Overview

This document describes how to use the tools and skills created for the migration workflow, including graph/vector ingestion, citations, and MCP connectivity.
All migration steps must be executed via MCP + LLM combined workflows with generator/judge agents and human approval gates.

## Tooling

### Python environment (uv)

- Location: `c:\Users\shara\code\migration\workspace\.venv`
- Purpose: Isolated environment for ingestion and validation utilities.
- Activation (PowerShell):
  - `.venv\Scripts\activate`

### Podman services

- Compose file: `c:\Users\shara\code\migration\workspace\podman-compose.yml`
- Services:
  - Neo4j (graph)
  - Qdrant (vector)

### DuckDB

- Use: Validate Parquet ingestion (counts, orphan edges, partition skew, joins).
- Querying is used for citation coverage checks.

### Parquet

- Use: Store nodes, edges, and file metadata for graph/vector ingestion.
- Partitioning: `context`, `entityType` (nodes), `relationType` (edges), plus hash bucketing.

### Sentence Transformers

- Use: Generate semantic embeddings for files using the configured model.
- Default model: `sentence-transformers/all-MiniLM-L6-v2`.
- Comment vectors: source comments and generated summaries are stored separately in Qdrant collections `code_comments` and `generated_comments`.
- Generated summaries use an LLM only when `--summary-mode llm` is enabled and `LLM_API_BASE`, `LLM_API_KEY`, `LLM_MODEL` are set; otherwise summaries are skipped.
- Providers: `openai`, `claude`, `gemini` via `--llm-provider` or `LLM_PROVIDER`.
- Stored procedure vectors are stored in `stored_procedures`.

### Roslyn extractor

- Use: Parse C# and VB projects with Roslyn to extract types, methods, LINQ, ORM usage, and stored procedure calls.
- Output: `c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl`.

### Stored procedure extraction

- Stored procedure definitions are extracted to `c:\Users\shara\code\migration\workspace\data\stored_procs`.
- Stored procedure nodes are added to the graph and embedded into Qdrant (`stored_procedures` collection).

### Config parsing fallback

- Order: Roslyn (C#/VB) -> tree-sitter -> regex.
- Applies to config files (`.config`, `.xml`, `.json`, `.yaml`, `.yml`, `.ini`, `.toml`, `.env`, `.props`, `.settings`, `.wsdl`, `.xsd`).

### Entrypoint tagging

- Frontend entrypoints (`.aspx`, `.ascx`, `.cshtml`, `.asax`) are labeled as `Entrypoint` with `entryKind=frontend`.
- `FRONTEND_HANDLED_BY` edges link entrypoints to code-behind classes when detected.
- API/SOAP/WCF entrypoints (`.ashx`, `.asmx`, `.svc`) are labeled as `Entrypoint` with `entryKind=api`, `soap`, or `wcf`.
- SOAP/WCF attributes (`[WebService]`, `[WebMethod]`, `[ServiceContract]`, `[OperationContract]`) create `SoapEndpoint`, `SoapOperation`, `WcfService`, and `WcfOperation` nodes with handler edges.
- VB equivalents (`<WebService>`, `<WebMethod>`, `<ServiceContract>`, `<OperationContract>`) are also captured.
- `.asmx`/`.svc` entrypoints also link to service nodes via `ENTRYPOINT_SERVICE`.
- SOAP/WCF service nodes are keyed on service class when available to avoid duplicates.

Example (SOAP de-dup):
```
[WebService]
public class CustomerService : WebService
{
    [WebMethod]
    public string Ping() => "ok";
}
```
- `SoapEndpoint` uses `serviceKey = "<rel_path>:CustomerService"` and both the `.asmx` entrypoint and attribute parser link to the same node.

### LLM summary prompts

- System prompt: `c:\Users\shara\code\migration\workspace\prompts\summary-system.md`
- User prompt: `c:\Users\shara\code\migration\workspace\prompts\summary-user.md`

## Skills and agent workflow

### Generator and Judge agents

- Every deliverable is produced by a Generator agent and validated by a Judge agent.
- Human approval is required after judge review.
- All approvals must be logged in `c:\Users\shara\code\migration\workspace\approvals\approvals.log`.
- Run agents in this order:
  1) `Agent-UL-Gen-1` -> `Agent-UL-Judge-1`
  2) `Agent-BRD-Gen-2` -> `Agent-BRD-Judge-2`
  3) `Agent-Gherkin-Gen-3` -> `Agent-Gherkin-Judge-3`
  4) `Agent-BC-Gen-4` -> `Agent-BC-Judge-4`
  5) `Agent-Map-Gen-5` -> `Agent-Map-Judge-5`
  6) `Agent-Code-Gen-6` -> `Agent-Code-Judge-6`
  7) `Agent-Test-Gen-7` -> `Agent-Test-Judge-7`

### Prompt catalog (no hard-coded prompts)

- Agent names are maintained in `c:\Users\shara\code\migration\workspace\prompts\agents.md`.
- Workflow header template lives in `c:\Users\shara\code\migration\workspace\prompts\workflow-header.md`.
- System prompts for MCP are defined in the agent files under `c:\Users\shara\code\migration\.github\agents`.
- BRD template: `c:\Users\shara\code\migration\workspace\prompts\brd-template.md`.
- Context README template: `c:\Users\shara\code\migration\workspace\prompts\context-readme-template.md`.
- Reqnroll README template: `c:\Users\shara\code\migration\workspace\prompts\reqnroll-readme-template.md`.
- Project README template: `c:\Users\shara\code\migration\workspace\prompts\project-readme-template.md`.
- Scripts load these files via `workspace\scripts\prompt_catalog.py` instead of embedding strings.

### Citation requirements

- Citations must be derived from graph/vector indexes, not direct file-only inspection.
- Citation format: `relative\path\to\File.cs:line`.
- Each section in a deliverable must have at least one citation.

### Coverage reporting (post-code)

- Produce `workspace/deliverables/generated/coverage-report.md` after forward engineering.
- Use Neo4j for legacy totals (files, entrypoints, classes, methods).
- Use Qdrant to validate semantic coverage of key legacy components.
- Use the full citation index at `workspace/deliverables/generated/citations/index.md` (build with `--limit 0 --file-limit 0 --rel-limit 0`) to cross-check cited legacy files.
- Report: total legacy items, cited items, coverage percentage, and top gaps.
- Coverage formulas:
  - File coverage % = cited legacy files / total legacy files
  - Entrypoint coverage % = cited entrypoints / total entrypoints
  - API coverage % = cited API entrypoints / total API entrypoints
  - Class coverage % = cited classes / total classes
  - Method coverage % = cited methods / total methods
  - Qdrant evidence coverage % = cited items with at least one matching vector hit / total cited items

## MCP server usage

- Provide both stdio and HTTP options in the MCP deliverable.
- Ensure MCP clients can query the graph/vector stores (Neo4j, Qdrant).
- Server name is `graph-vector-mcp` and is returned in `list_tools`.
- MCP prompts are exposed via `list_prompts` and `get_prompt`.
- Full endpoint discovery guide is in `c:\Users\shara\code\migration\workspace\deliverables\generated\mcp-options.md`.
- Copilot Chat MCP config file is `c:\Users\shara\code\migration\workspace\deliverables\generated\copilot-mcp.json`.
- VS Code MCP config: `c:\Users\shara\code\migration\.vscode\mcp.json` (server name `mcp-migration`).
- Start MCP HTTP server:
  - `powershell -ExecutionPolicy Bypass -File c:\Users\shara\code\migration\workspace\scripts\start_mcp_http.ps1`

## Guardrails

- Incremental generation: one bounded context or feature set at a time.
- Max 2 iterations per deliverable unless human approval extends.
- Pause and request direction if a blocker persists after 2 iterations.

## Next steps

## Scripts

### Ingest legacy code to Parquet

- Script: `c:\Users\shara\code\migration\workspace\scripts\ingest_legacy.py`
- Purpose: Parse legacy code, emit Parquet datasets for nodes, edges, files, and vectors.
- Example:
  - `.venv\Scripts\python scripts\ingest_legacy.py --root D:\code\migration\code --max-files 1000`

### Load Parquet into Neo4j and Qdrant

- Script: `c:\Users\shara\code\migration\workspace\scripts\load_graph_vector.py`
- Purpose: Upsert nodes/edges into Neo4j and vectors into Qdrant.
- Example:
  - `.venv\Scripts\python scripts\load_graph_vector.py`

### Validate Parquet with DuckDB

- Script: `c:\Users\shara\code\migration\workspace\scripts\validate_parquet.py`
- Purpose: Check counts and orphan edges.
- Example:
  - `.venv\Scripts\python scripts\validate_parquet.py`

### Build citation index from Neo4j

- Script: `c:\Users\shara\code\migration\workspace\scripts\build_citation_index.py`
- Purpose: Produce a full citation index derived from the graph.
- Example:
  - `.venv\Scripts\python scripts\build_citation_index.py --limit 0 --file-limit 0 --rel-limit 0`

### Run Roslyn extractor

- Command: `dotnet run --project c:\Users\shara\code\migration\workspace\roslyn_extractor -- --root D:\code\migration\code --out c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl`

## Next steps

- Install Python deps (duckdb, pyarrow, neo4j/qdrant clients).
- Start Podman services and verify connectivity.
- Ingest legacy repo into Parquet.
- Load Parquet into Neo4j/Qdrant.
- Build the citation index.
- Run agents in order: UL -> BRD -> Gherkin+tests -> Bounded contexts -> Code -> Test results.
- API mapping must be completed and reviewed before code generation.
