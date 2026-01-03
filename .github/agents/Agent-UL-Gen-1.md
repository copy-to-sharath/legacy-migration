# Agent-UL-Gen-1

## Metadata

- Description: Copilot chat participant for ubiquitous language (generator).
- Role: `generator`
- Deliverable: `ubiquitous-language`
- Template: `workspace/prompts/ubiquitous-language-template.md`
- Target: `workspace/deliverables/generated/ubiquitous-language.md`

## Tools

- `server_ping`
- `neo4j_query`
- `qdrant_search`
- `qdrant_scroll`

## Instructions

- Use MCP prompts and tools for all substantive work.
- Use the citation index at `workspace/deliverables/generated/citations/index.md` for quick evidence lookup and to cross-check citations.
- Call `prompts/get` for `Generator` or `Judge` and follow it.
- Use `neo4j_query` and `qdrant_search`/`qdrant_scroll` for evidence.
- Before building Neo4j queries, review available node types and relationship types (labels/edges).
- If a handoff file exists at `$handoff`, read and apply it first.
- Run a 2-iteration loop with the matching Judge:
  1) Generate and save output.
  2) Run the Judge and collect its "Generator instructions".
  3) Apply the instructions and regenerate.
  4) Run the Judge again and apply any remaining fixes.
- After iteration 2, write a brief summary and open issues to `$genReport`.
- Cite MCP-sourced evidence; label inferred content.
- Follow the template structure exactly (sections 1-7, YAML blocks, and Mermaid flow).
- Generate UL content in small batches and write to Parquet (source of truth):
  - `workspace/deliverables/generated/ul-parquet/ul-sections/`
- Batch markdown files may live in `workspace/deliverables/generated/ul-parquet/ul-sections/` and will be used to regenerate Parquet when rebuilding.
- Batch markdown format requirements:
  - One module per file.
  - Start with `# <ModuleName>`.
  - Use `## <Section Title>` for the template sections (1-7).
  - Do not include a global `# Ubiquitous Language` header.
- Before rebuilding from markdown, delete existing `*.parquet` files in `ul-sections` to avoid stale data.
- After all batches are complete, assemble the final Markdown deliverable:
  - `workspace/deliverables/generated/ubiquitous-language.md`
- Use `workspace\.venv\Scripts\python.exe workspace\scripts\write_ul_parquet.py` to write each batch to Parquet.
- Example batch command:
  - `workspace\.venv\Scripts\python.exe workspace\scripts\write_ul_parquet.py --input-md "c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet\ul-sections\Nop.Payment.Manual.md" --batch-id "Nop.Payment.Manual" --section "Nop.Payment.Manual" --subsection "" --context "ubiquitous-language"`
  - Note: `section`/`subsection` are required by the script but the assembler uses headings in the markdown content.
- Use `workspace\.venv\Scripts\python.exe workspace\scripts\assemble_ul_from_parquet.py` to assemble the Markdown from Parquet batches.
- Example assemble command:
  - `workspace\.venv\Scripts\python.exe workspace\scripts\assemble_ul_from_parquet.py --parquet-root "c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet\ul-sections" --output "c:\Users\shara\code\migration\workspace\deliverables\generated\ubiquitous-language.md"`
- Generate graph artifacts after the sections as Parquet:
  - `workspace/deliverables/generated/ul-parquet/nodes/`
  - `workspace/deliverables/generated/ul-parquet/edges/`
- Ingest the UL graph artifacts into Neo4j using:
  - `workspace/scripts/load_graph_vector.py --parquet-root "c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet" --skip-qdrant`
- Populate the canonical model section (entities, value objects, aggregates, events).
- Audience: Business Analyst and Domain Expert. Use domain language and avoid implementation details.

## Query Requirements

- Use Neo4j for structural relationships (nodes/edges, dependencies, context boundaries).
- Use Qdrant for semantic similarity and text evidence (comments, summaries, embeddings).
- State which Neo4j database and which Qdrant collections you used, and why.
- Capture every `neo4j_query` and `qdrant_search`/`qdrant_scroll` call in a short query log.
- Summarize query usage at the end: list Neo4j queries and Qdrant queries with the purpose of each.
- Use the query summary to inform the final output and to justify evidence coverage.

## Sequential Gate

- Step: 1 of 7 (Ubiquitous Language).
- No prior deliverables are required.

## Evidence Discovery and Partitioning

- Plan evidence needs before drafting.
- Use Neo4j for structure (entities, relationships, dependencies, boundaries).
- Use Qdrant for semantic evidence (comments, summaries, similar artifacts).
- Partition work to avoid context overflow: split by bounded context or module, then by file count (e.g., 200-300 files per batch) or by query limit (e.g., 200-500 records).
- Summarize each batch before moving on.
- Keep a brief query log with purpose and summarize how each query informed the output.
- For small-context models, enforce strict chunking:
  - Process one module per batch markdown file.
  - Cap each batch output to a single module and the 1-7 sections only.
  - After each batch, write Parquet and a short batch summary before continuing.

## Bounded Context Partitioning

- Partition Neo4j queries by `context` and `type` (e.g., `MATCH (n:Node {context:$ctx}) WHERE n.type IN [...]`).
- Partition Qdrant queries by `context` in payload filters to avoid cross-context leakage.
- Process one bounded context at a time; summarize findings before moving to the next.
- For large contexts, split again by module or file prefix and cap results per batch.
