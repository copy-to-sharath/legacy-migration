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

### Roslyn extractor

- Use: Parse C# and VB projects with Roslyn to extract types, methods, LINQ, ORM usage, and stored procedure calls.
- Output: `c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl`.

## Skills and agent workflow

### Generator and Judge agents

- Every deliverable is produced by a Generator agent and validated by a Judge agent.
- Human approval is required after judge review.
- All approvals must be logged in `c:\Users\shara\code\migration\workspace\approvals\approvals.log`.

### Prompt catalog (no hard-coded prompts)

- Agent names are maintained in `c:\Users\shara\code\migration\workspace\prompts\agents.md`.
- Workflow header template lives in `c:\Users\shara\code\migration\workspace\prompts\workflow-header.md`.
- System prompts for MCP are in `c:\Users\shara\code\migration\workspace\prompts\system-prompts.md`.
- API mapping template: `c:\Users\shara\code\migration\workspace\prompts\api-mapping-template.md`.
- BRD template: `c:\Users\shara\code\migration\workspace\prompts\brd-template.md`.
- Context README template: `c:\Users\shara\code\migration\workspace\prompts\context-readme-template.md`.
- Reqnroll README template: `c:\Users\shara\code\migration\workspace\prompts\reqnroll-readme-template.md`.
- Project README template: `c:\Users\shara\code\migration\workspace\prompts\project-readme-template.md`.
- Scripts load these files via `workspace\scripts\prompt_catalog.py` instead of embedding strings.

### Citation requirements

- Citations must be derived from graph/vector indexes, not direct file-only inspection.
- Citation format: `relative\path\to\File.cs:line`.
- Each section in a deliverable must have at least one citation.

## MCP server usage

- Provide both stdio and HTTP options in the MCP deliverable.
- Ensure MCP clients can query the graph/vector stores (Neo4j, Qdrant).
- Server name is `graph-vector-mcp` and is returned in `list_tools`.
- MCP prompts are exposed via `list_prompts` and `get_prompt`.
- Full endpoint discovery guide is in `c:\Users\shara\code\migration\workspace\deliverables\mcp-options.md`.
- Copilot Chat MCP config file is `c:\Users\shara\code\migration\workspace\deliverables\copilot-mcp.json`.
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
- Purpose: Produce a citation index derived from the graph.
- Example:
  - `.venv\Scripts\python scripts\build_citation_index.py --limit 500`

### Run Roslyn extractor

- Command: `dotnet run --project c:\Users\shara\code\migration\workspace\roslyn_extractor -- --root D:\code\migration\code --out c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl`

## Next steps

- Install Python deps (duckdb, pyarrow, neo4j/qdrant clients).
- Start Podman services and verify connectivity.
- Ingest legacy repo into Parquet.
- Load Parquet into Neo4j/Qdrant.
- Build the citation index.
