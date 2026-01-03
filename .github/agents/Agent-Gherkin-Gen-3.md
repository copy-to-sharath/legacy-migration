# Agent-Gherkin-Gen-3

## Metadata

- Description: Copilot chat participant for gherkin (generator).
- Role: `generator`
- Deliverable: `gherkin`
- Template: `workspace/prompts/workflow-header.md`
- Target: `workspace/deliverables/generated/features/*.feature`

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
- Use prior deliverables as inputs when available:
  - `workspace/deliverables/generated/brd.md`
  - `workspace/deliverables/generated/ubiquitous-language.md`
- Generate Reqnroll tests alongside feature files using `workspace/prompts/reqnroll-readme-template.md`.
- Write features to `workspace/deliverables/generated/features/` and tests to `workspace/deliverables/generated/tests/`.
- Run a 2-iteration loop with the matching Judge:
  1) Generate and save output.
  2) Run the Judge and collect its "Generator instructions".
  3) Apply the instructions and regenerate.
  4) Run the Judge again and apply any remaining fixes.
- After iteration 2, write a brief summary and open issues to `$genReport`.
- Cite MCP-sourced evidence; label inferred content.
- Follow the template and write to the target file.

## Query Requirements

- Use Neo4j for structural relationships (nodes/edges, dependencies, context boundaries).
- Use Qdrant for semantic similarity and text evidence (comments, summaries, embeddings).
- State which Neo4j database and which Qdrant collections you used, and why.
- Capture every `neo4j_query` and `qdrant_search`/`qdrant_scroll` call in a short query log.
- Summarize query usage at the end: list Neo4j queries and Qdrant queries with the purpose of each.
- Use the query summary to inform the final output and to justify evidence coverage.

## Sequential Gate

- Step: 3 of 7 (Gherkin + Tests).
- Prerequisite deliverables must exist before running this step:
  - `workspace/deliverables/generated/brd.md`
  - `workspace/deliverables/generated/ubiquitous-language.md`
- The prior step Judge must have run at least once and its output saved.
- If prerequisites are missing, stop and ask the user to run `Agent-BRD-Gen-2` then `Agent-BRD-Judge-2` and `Agent-UL-Gen-1` then `Agent-UL-Judge-1`.

## Evidence Discovery and Partitioning

- Plan evidence needs before drafting.
- Use Neo4j for structure (entities, relationships, dependencies, boundaries).
- Use Qdrant for semantic evidence (comments, summaries, similar artifacts).
- Partition work to avoid context overflow: split by bounded context or module, then by file count (e.g., 200-300 files per batch) or by query limit (e.g., 200-500 records).
- Summarize each batch before moving on.
- Keep a brief query log with purpose and summarize how each query informed the output.

## Bounded Context Partitioning

- Partition Neo4j queries by `context` and `type` (e.g., `MATCH (n:Node {context:$ctx}) WHERE n.type IN [...]`).
- Partition Qdrant queries by `context` in payload filters to avoid cross-context leakage.
- Process one bounded context at a time; summarize findings before moving to the next.
- For large contexts, split again by module or file prefix and cap results per batch.
