---
title: Migration Workspace
---

# Migration Workspace

## Source code ingestion

This pipeline ingests a legacy codebase, builds graph/vector data, loads it into Neo4j and Qdrant, and creates a citation index.

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

### 2) Run ingestion to Parquet

This scans supported source files and produces parquet datasets under `workspace/data/parquet`.

```powershell
workspace\.venv\Scripts\python.exe workspace\scripts\ingest_legacy.py `
  --root "D:\code\migration\code" `
  --out "c:\Users\shara\code\migration\workspace\data\parquet" `
  --state-file "c:\Users\shara\code\migration\workspace\state\ingest_state.json"
```

Notes:
- The ingest uses `state/ingest_state.json` to resume. Delete it if you want a clean run.
- Increase `--max-files` / `--batch-size` for larger runs.

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
  --collection "code_vectors"
```

Optional flags:
- `--skip-neo4j` to load only Qdrant.
- `--skip-qdrant` to load only Neo4j.

### 5) Build citation index

```powershell
workspace\.venv\Scripts\python.exe workspace\scripts\build_citation_index.py `
  --neo4j-uri "bolt://localhost:7687" `
  --neo4j-user "neo4j" `
  --neo4j-password "neo4j12#456" `
  --output "c:\Users\shara\code\migration\workspace\deliverables\citations\index.md"
```
