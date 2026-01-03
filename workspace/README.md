---
title: Migration Workspace
---

# Migration Workspace

## Source code ingestion

This pipeline ingests a legacy codebase, builds graph/vector data, loads it into Neo4j and Qdrant, and creates a full citation index.

## Ubiquitous language

- Template: `workspace/prompts/ubiquitous-language-template.md`
- Draft deliverable: `workspace/deliverables/generated/ubiquitous-language.md`
- Populate from the legacy codebase; later steps refine it with BRD/Gherkin artifacts.

## Agent workflow order

Use this order when running Copilot Chat agents. Each step requires the matching Judge to run at least once before the next step starts.

1) Ubiquitous language generation (legacy code)
   - Generator: `Agent-UL-Gen-1`
   - Judge: `Agent-UL-Judge-1`
   - Output: `workspace/deliverables/generated/ubiquitous-language.md`
2) BRD generation
   - Generator: `Agent-BRD-Gen-2`
   - Judge: `Agent-BRD-Judge-2`
   - Output: `workspace/deliverables/generated/brd.md`
3) Gherkin generation + test cases
   - Generator: `Agent-Gherkin-Gen-3`
   - Judge: `Agent-Gherkin-Judge-3`
   - Outputs: `workspace/deliverables/generated/features/*.feature`, `workspace/deliverables/generated/tests/`
4) Bounded context / DDD specs
   - Generator: `Agent-BC-Gen-4`
   - Judge: `Agent-BC-Judge-4`
   - Output: `workspace/deliverables/generated/bounded-contexts.md`
5) API mapping + coverage
   - Generator: `Agent-Map-Gen-5`
   - Judge: `Agent-Map-Judge-5`
   - Output: `workspace/deliverables/generated/api-mapping.md`
6) Forward engineering code generation
   - Generator: `Agent-Code-Gen-6`
   - Judge: `Agent-Code-Judge-6`
   - Outputs:
     - `workspace/deliverables/generated/src/`
     - `workspace/deliverables/generated/coverage-report.md`
7) Test results (integration, performance, security)
   - Generator: `Agent-Test-Gen-7`
   - Judge: `Agent-Test-Judge-7`
   - Outputs: `workspace/deliverables/generated/tests/`, `workspace/deliverables/generated/src/`

### Prerequisites

- Python venv at `workspace/.venv` with required deps (`sentence-transformers`, `pyarrow`, `duckdb`, `neo4j`, `qdrant-client`).
- .NET SDK for the Roslyn extractor.
- Neo4j running at `bolt://localhost:7687` (default credentials in scripts).
- Qdrant running at `http://localhost:6333`.

### 1) Build Roslyn index (C# / VB)

The ingestion relies on a Roslyn index file. Build it before running the Python ingest:

```powershell
dotnet run --project workspace/roslyn_extractor/roslyn_extractor.csproj -- `
  --root "D:\code\migration\code" `
  --out "c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl" `
  --missing-log "c:\Users\shara\code\migration\workspace\state\roslyn_missing.txt"
```

## Clean restart (from scratch)

Use this when you want to wipe local ingestion outputs and rebuild everything from the Roslyn index onward.

### A) Stop services and wipe Neo4j/Qdrant data

```powershell
podman compose -f workspace\podman-compose.yml down --volumes
podman volume rm workspace_neo4j_data workspace_neo4j_logs
```

### B) Remove local ingestion outputs

```powershell
Remove-Item -Force -ErrorAction SilentlyContinue -Path `
  workspace\data\roslyn\roslyn.jsonl, `
  workspace\deliverables\generated\citations\index.md
Remove-Item -Force -Recurse -ErrorAction SilentlyContinue -Path workspace\data\parquet
Remove-Item -Force -Recurse -ErrorAction SilentlyContinue -Path workspace\state\*
```

If you also want to clear generated deliverables, remove the entire deliverables folder:

```powershell
Remove-Item -Force -Recurse -ErrorAction SilentlyContinue -Path workspace\deliverables
```

### C) Restart the full ingestion process

Start services before step 4:

```powershell
podman compose -f workspace\podman-compose.yml up -d
```

1) Recreate the Roslyn index (step 1)
2) Run ingestion to Parquet (step 2)
3) Validate parquet outputs (step 3)
4) Load Neo4j + Qdrant (step 4)
5) Build full citation index (step 5)

### 2) Run ingestion to Parquet

This scans supported source files and produces parquet datasets under `workspace/data/parquet`.

```powershell
workspace\.venv\Scripts\python.exe workspace\scripts\ingest_legacy.py `
  --root "D:\code\migration\code" `
  --out "c:\Users\shara\code\migration\workspace\data\parquet" `
  --state-file "c:\Users\shara\code\migration\workspace\state\ingest_state.json" `
  --summary-mode "llm" `
  --llm-provider "openai" `
  --stored-proc-dir "c:\Users\shara\code\migration\workspace\data\stored_procs" `
  --progress-every 25
```

Notes:
- The ingest uses `state/ingest_state.json` to resume. Delete it if you want a clean run.
- During ingestion, the state file is updated with progress fields (`processed`, `total`, `range_start`, `range_end`, `status`) every `--progress-every` files.
- Increase `--max-files` / `--batch-size` for larger runs.
- LLM summaries require `LLM_API_BASE`, `LLM_API_KEY`, and `LLM_MODEL` environment variables; otherwise summaries are skipped.
- Set `LLM_PROVIDER` to `openai`, `claude`, or `gemini` (or use `--llm-provider`).

### 3) Validate parquet outputs

```powershell
workspace\.venv\Scripts\python.exe workspace\scripts\validate_parquet.py `
  --parquet-root "c:\Users\shara\code\migration\workspace\data\parquet"
```

### 4) Load Neo4j + Qdrant

```powershell
workspace\.venv\Scripts\python.exe workspace\scripts\load_graph_vector.py `
  --parquet-root "c:\Users\shara\code\migration\workspace\data\parquet" `
  --neo4j-uri "bolt://localhost:7687" `
  --neo4j-user "neo4j" `
  --neo4j-password "neo4j12#456" `
  --qdrant-url "http://localhost:6333" `
  --collection-code "code_vectors" `
  --collection-comments "code_comments" `
  --collection-generated "generated_comments" `
  --collection-procs "stored_procedures"
```

Optional flags:
- `--skip-neo4j` to load only Qdrant.
- `--skip-qdrant` to load only Neo4j.

### 5) Build full citation index

```powershell
workspace\.venv\Scripts\python.exe workspace\scripts\build_citation_index.py `
  --neo4j-uri "bolt://localhost:7687" `
  --neo4j-user "neo4j" `
  --neo4j-password "neo4j12#456" `
  --output "c:\Users\shara\code\migration\workspace\deliverables\generated\citations\index.md" `
  --limit 0 --file-limit 0 --rel-limit 0
```
