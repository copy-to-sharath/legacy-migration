# Build Plan

1) Bootstrap workspace tooling: uv env, Python deps (duckdb, pyarrow, neo4j/qdrant clients), Podman services; verify connectivity.
2) Configure MCP server connectivity (stdio + HTTP) and verify local clients can query graph/vector stores.
   - Confirm MCP prompts are loaded from `workspace\prompts\system-prompts.md` via `list_prompts`/`get_prompt`.
3) Ingest legacy repo into Parquet + graph/vector indexes; build citation index via graph/vector queries and DuckDB validation.
4) Produce documentation artifacts in order (ingestion plan -> BRD -> bounded contexts -> Gherkin -> Reqnroll tests -> API mapping -> .NET 8 design spec -> MCP options), each via MCP + LLM with generator/judge + approval gates.
5) Implement .NET 8 solution incrementally by bounded context via MCP + LLM; add tests, run build/host/test, and update mapping/coverage until parity gates pass.

## MCP + LLM implementation approach (no hard-coded heuristics)

1) Refresh context keywords via MCP:
   - Script: `workspace/scripts/generate_context_keywords_via_mcp.py`
   - Inputs: `workspace/deliverables/bounded-contexts.md`, Neo4j graph
   - Output: `workspace/state/context_keywords.json`

2) Query graph/vector via MCP for citations and endpoints:
   - Neo4j for endpoints, services, modules, code hints
   - Qdrant for vector-backed citation samples

3) Generate/refresh API mapping via MCP:
   - Script: `workspace/scripts/next_steps_llm_mcp.py` (or `next_steps_full_via_mcp.py`)
   - Output: `workspace/deliverables/api-mapping.md`
   - Classification uses `context_keywords.json` only

4) Implement per-context logic in layers (LLM + MCP citations):
   - Domain: entities + value objects
   - Application: DTOs + service contracts
   - Infrastructure: in-memory implementations (placeholder for persistence)
   - API: controllers with evidence comments from MCP queries

5) Reqnroll alignment:
   - Regenerate bindings from feature files via MCP: `workspace/scripts/fix_reqnroll_steps_via_mcp.py`
   - Run tests: `dotnet test workspace/deliverables/src/Migration.sln`

6) Iterate context-by-context:
   - Expand features and mapping using MCP data only
   - Replace in-memory infra with real persistence as design stabilizes
7) BRD generation (MCP-derived citations):
   - Source of truth: Neo4j + Qdrant via MCP (no direct file inspection)
   - Output: `workspace/deliverables/brd.md`
   - Ensure LLM-inferred content is explicitly labeled

## MCP step-by-step execution

1) Start MCP server (stdio):
   - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\mcp_server\mcp_server.py --transport stdio --server-name graph-vector-mcp`

2) Generate context keywords from MCP:
   - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\scripts\generate_context_keywords_via_mcp.py`
   - Output: `workspace/state/context_keywords.json`

3) Build deliverables via MCP:
   - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\scripts\generate_deliverables_via_mcp.py`
   - Outputs: `workspace/deliverables/api-mapping.md`, `workspace/deliverables/tests/*.cs`, `workspace/deliverables/src/Contexts/*`

4) Refresh tests and controller stubs via MCP:
   - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\scripts\next_steps_llm_mcp.py`
   - Also updates API mapping + controllers and runs tests.

5) Fix Reqnroll step bindings via MCP:
   - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\scripts\fix_reqnroll_steps_via_mcp.py`

6) Full MCP run (mapping + controllers + tests):
   - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\scripts\next_steps_full_via_mcp.py`
