# Migration Plan (.NET 4.5 -> DDD + BDD Gherkin APIs)

## Status & prerequisites

- **Code citations pending**: Source code is available at `D:\code\migration\code` (sample project). All deliverables must include citations to existing code. Use file/line references from that repo.
- **Workspace root**: All artifacts are generated under `c:\Users\shara\code\migration\workspace`.
- **Deliverables location**: Generated outputs live under `workspace/deliverables/generated` (delete `workspace/deliverables` to reset).
- **Human approvals**: All approvals must be documented and retained. Use `workspace/approvals/approvals.log` with timestamp, approver, decision, scope, and rationale.
- **Copilot approvals**: Use a VS Code GitHub Copilot approval workflow before any deliverable is finalized; document the approval in the log.
- **Complete rewrite**: This project is a full rewrite to .NET 8 with behavior parity from legacy code; migration is not in-place.
- **Solution structure**: Multiple projects under a single solution.
- **API style**: REST-based endpoints for the rewrite.
- **Scale**: Very large project (millions of nodes/edges/vectors); design for horizontal scale and partitioned Parquet ingestion.
- **Local runtime**: Use Podman to run Neo4j and Qdrant locally.
- **Operational notice**: If ingestion or graph/vector loading is interrupted, notify the user and resume from the saved state.

## Deliverables

0) **GraphDB + VectorDB ingestion plan**
   - Generator agent: `Agent-Graph-Gen`
   - Judge agent: `Agent-Graph-Judge`
   - Output: `workspace/deliverables/generated/graph-ingestion.md`
   - Requirements: Use Parquet partitioning for nodes/edges; cite code that identifies entities/relations.

1) **Ubiquitous language (from legacy code)**
   - Generator agent: `Agent-UL-Gen-1`
   - Judge agent: `Agent-UL-Judge-1`
   - Output: `workspace/deliverables/generated/ubiquitous-language.md`
   - Requirements: Cite legacy code evidence; populate canonical model sections.

2) **BRD (Business Requirements Document)**
   - Generator agent: `Agent-BRD-Gen-2`
   - Judge agent: `Agent-BRD-Judge-2`
   - Output: `workspace/deliverables/generated/brd.md`
   - Requirements: Cite code where current behavior is inferred; if LLM knowledge is used, call it out explicitly in BRD.

3) **BDD Gherkin feature files + tests**
   - Generator agent: `Agent-Gherkin-Gen-3`
   - Judge agent: `Agent-Gherkin-Judge-3`
   - Outputs:
     - `workspace/deliverables/generated/features/*.feature`
     - `workspace/deliverables/generated/tests/` (Reqnroll)
   - Requirements: Each scenario links back to code that implements or hints the behavior; tests align to features with citations.

4) **Bounded contexts / DDD specs**
   - Generator agent: `Agent-BC-Gen-4`
   - Judge agent: `Agent-BC-Judge-4`
   - Output: `workspace/deliverables/generated/bounded-contexts.md`
   - Requirements: Each context has citations to original code (e.g., `src/Module/Foo.cs:120`).

5) **Legacy-to-new API mapping and coverage**
   - Generator agent: `Agent-Map-Gen-5`
   - Judge agent: `Agent-Map-Judge-5`
   - Output: `workspace/deliverables/generated/api-mapping.md`
   - Requirements:
     - Document old endpoints with request/response shapes and citations.
     - Document new endpoints with request/response shapes and citations.
     - Map old -> new endpoints and note deprecations or splits/merges.
     - Document any new endpoints introduced by bounded contexts.
     - Provide coverage summary showing which legacy endpoints are mapped, pending, or dropped.
   - Gate: mapping complete, citations verified, judge review complete, approval logged.

6) **Forward-engineered .NET 8 code (DDD + BDD + Clean Architecture)**
   - Generator agent: `Agent-Code-Gen-6`
   - Judge agent: `Agent-Code-Judge-6`
   - Output: `workspace/deliverables/generated/src/` (new solution layout)
   - Requirements: Code compiles, can be hosted, unit tests pass; cite legacy code for behavior parity.
   - Coverage: Produce `workspace/deliverables/generated/coverage-report.md` using Neo4j, Qdrant, and the citation index.

7) **Test results (integration/performance/security)**
   - Generator agent: `Agent-Test-Gen-7`
   - Judge agent: `Agent-Test-Judge-7`
   - Outputs:
     - `workspace/deliverables/generated/tests/`
     - `workspace/deliverables/generated/src/`
   - Requirements: Report integration, performance, and security testing outcomes with evidence.

### Optional deliverables

- **MCP server connectivity options**
  - Generator agent: `Agent-MCP-Gen`
  - Judge agent: `Agent-MCP-Judge`
  - Output: `workspace/deliverables/generated/mcp-options.md`
  - Requirements: Provide both stdio and HTTP options; include any code references for config if applicable.
- **Legacy-to-new API mapping and coverage**
  - Generator agent: `Agent-Map-Gen-5`
  - Judge agent: `Agent-Map-Judge-5`
  - Output: `workspace/deliverables/generated/api-mapping.md`
  - Requirements:
    - Document old endpoints with request/response shapes and citations.
    - Document new endpoints with request/response shapes and citations.
    - Map old -> new endpoints and note deprecations or splits/merges.
    - Document any new endpoints introduced by bounded contexts.
    - Provide coverage summary showing which legacy endpoints are mapped, pending, or dropped.

## Planned workflow

### Phase 0: Approvals, access, and inventory

- Obtain human approval to proceed.
- Log approval in `workspace/approvals/approvals.log`.
- All deliverables are written under `workspace/`.
- Use a VS Code GitHub Copilot approval workflow:
  - Generator produces draft, judge reviews, human approves in VS Code.
  - Record approver, decision, and notes in the approval log.
- Collect repository inventory (projects, namespaces, APIs, data access, domain models, tests).
- Build a citation index with file+line references for all deliverables.
- Gate: approval logged, inventory complete, citation index created.

### Citation extraction (required)

- Build a searchable graph/vector index of legacy code with file+line references (no direct file-only citation workflow).
- Use consistent citation format: `relative\path\to\File.cs:line`.
- Capture endpoints, domain models, services, and configuration sources through graph+vector extraction.
- Store citation index in `workspace/deliverables/generated/citations/index.md` (or CSV) for reuse across deliverables.

### Phase 1: Graph/Vector ingestion

- Extract node/edge schemas per context, traversing multiple solutions and projects.
- Include C#, VB, ASPX, and related project assets; document all relevant file types into Parquet.
- Use Parquet for data exchange (staging, partitions) and DuckDB for local querying/validation.
- Generate embeddings with Sentence Transformers (default `sentence-transformers/all-MiniLM-L6-v2`).
- Use Roslyn-based extraction for C# and VB to capture types, methods, LINQ, ORM usage, and stored procedure calls.
- Generate Roslyn index (`workspace/data/roslyn/roslyn.jsonl`) before Parquet ingestion.
- Roslyn index is required for C#/VB extraction; if missing or empty, stop and notify before deliverables proceed.
- Use plain file parsing for unknown file types (e.g., JSON/config) to ensure they are represented in Parquet (JSON flattening + key/value line extraction).
- Capture stored procedure names and usage as graph nodes/edges (e.g., `StoredProcedure`, `DECLARES_PROC`, `EXECUTES_PROC`).
- Partition strategy:
  - `nodes/` partition by `context`, `entityType`, and `hash(id)%N` (choose N based on total nodes).
  - `edges/` partition by `context`, `relationType`, and `hash(sourceId)%N`.
  - Keep Parquet row groups ~128-256 MB for performance.
- DuckDB validation checklist:
  - Node/edge row counts per partition and total.
  - Orphan edges (missing source/target nodes).
  - High-degree nodes distribution (skew check).
  - Partition size distribution (detect hot partitions).
  - Sample join queries across nodes/edges for referential consistency.
  - Citation coverage queries: each deliverable section has at least one cited node/edge.
- Parquet schema catalog (minimum):
  - `nodes`: `id`, `type`, `context`, `name`, `sourceFile`, `sourceLine`, `attributes` (JSON).
  - `edges`: `id`, `type`, `sourceId`, `targetId`, `context`, `sourceFile`, `sourceLine`, `attributes` (JSON).
  - `files`: `path`, `type`, `project`, `context`, `sourceLine` (if applicable), `attributes` (JSON).
- Gate: Parquet produced, DuckDB checks pass, approval logged.

### Phase 2: Ubiquitous language generation (legacy code)

- Extract domain terms and definitions from the legacy codebase.
- Populate the canonical model sections with citations.
- Gate: ubiquitous language complete, citations verified, judge review complete, approval logged.

### Phase 3: BRD generation

- Extract requirements from existing API controllers, services, and integration points.
- Build citation index for every key behavior and entity (file + line numbers).
- If LLM knowledge supplements gaps, label those sections explicitly in BRD.
- Gate: BRD complete, citations verified, judge review complete, approval logged.

### Phase 4: BDD (Gherkin) specification + tests

- Create features and scenarios aligned to the BRD with citations.
- Generate Reqnroll tests aligned to features.
- Keep traceability from feature -> test -> legacy code.
- Reqnroll setup checklist:
  - Define test project layout and naming conventions.
  - Define step binding conventions and shared hooks.
  - Ensure `dotnet test` is the default runner for CI parity.
- Gate: features + tests complete, citations verified, judge review complete, approval logged.

### Phase 5: Bounded context / DDD specs

- Identify bounded contexts by namespace/module boundaries and dependency graphs.
- Define aggregates, entities, value objects, domain services, and domain events per context.
- Map anti-corruption layers and context boundaries.
- Use citations for every mapping from legacy code.
- Gate: contexts finalized, citations verified, judge review complete, approval logged.

### Phase 6: API mapping and coverage

- Inventory legacy endpoints and document request/response shapes with citations.
- Include ASPX pages, ASMX/WCF services, HTTP handlers (`.ashx`), and modules as legacy endpoints.
- Document new endpoints with request/response shapes and citations.
- Create explicit old->new mapping (including split/merge/deprecations).
- Call out new endpoints introduced by bounded contexts.
- Provide coverage summary and gap list.
- Extract request/response shapes via graph/vector queries rather than direct file inspection.
- Gate: mapping complete, coverage summary verified, approval logged.

### Phase 7: Forward-engineered .NET 8 code

- Implement DDD + BDD compliant Clean Architecture solution in .NET 8.
- Ensure code compiles, can be hosted, and unit tests pass.
- Maintain behavior parity with legacy code, with citations.
- Produce coverage metrics using Neo4j, Qdrant, and the citation index.
- Gate: build+tests pass, behavior parity reviewed, approval logged.

### Phase 8: Test results (integration/performance/security)

- Run integration, performance, and security testing.
- Report results with evidence and blockers for deployment readiness.
- Gate: test results complete, judge review complete, approval logged.

## MCP server options (placeholder)

- **stdio**: MCP client spawns server process, communicates over stdin/stdout.
- **http**: MCP client connects to server over HTTP (REST or JSON-RPC), with health endpoints and auth.

## Human approval log template

```
Timestamp | Approver | Decision | Scope | Rationale | Notes
```

## Citation coverage checklist (per deliverable)

```
Deliverable:
Sections reviewed:
- Section name:
  - Has at least one citation (graph/vector-derived): Yes/No
  - Citation format correct: Yes/No
  - LLM-informed content explicitly labeled: Yes/No
Gaps noted:
Approver:
Decision:
Timestamp:
```

## Open items

- GraphDB: Neo4j (on-prem).
- VectorDB: Qdrant (on-prem).
- Confirm expected scale (nodes/edges) for partition sizing.

## Process improvement recommendations

- Add a traceability matrix that links legacy code -> BRD requirement -> bounded context -> feature -> test -> new code.
- Use automated dependency graphing to validate bounded context boundaries and prevent cyclic dependencies.
- Introduce a "behavior parity" checklist per feature to explicitly confirm match vs. improvements.
- Add performance baselines on legacy code paths and compare in .NET 8 rewrite.
- Establish a change approval gate before each deliverable is finalized (log in approvals file).
- Add an approval gate checklist for each deliverable: citations complete, judge review complete, human approval logged.
- Enforce graph/vector-only citation extraction; prohibit manual file-only citations.
- Add logging to all ingestion, load, and validation scripts; record progress and interruptions.

## Incremental generation guardrails

- Generate deliverables in small batches (one context or feature set at a time).
- Cap revision loops to 2 iterations per deliverable unless a human approval extends it.
- If a blocker persists after 2 iterations, pause and request direction.
- Log each iteration outcome in `workspace/approvals/approvals.log`.

## Prompt templates (domain-adaptable)

### Global prompt header (use in every agent)

```
You are working on a complete rewrite of a legacy .NET 4.5 codebase to .NET 8 using DDD + BDD (Gherkin) and Clean Architecture.
The legacy source is a sample project located at D:\code\migration\code.
Every output must cite legacy code files with file+line references.
If you use domain knowledge not present in code, explicitly label it as "LLM-informed".
Do not implement code yet; produce planning and documentation only.
```

### 1) GraphDB + VectorDB ingestion plan (Generator)

```
Task: Produce a GraphDB + VectorDB ingestion plan from the legacy code.
Scope: Identify entities, relationships, and embeddings sources.
Requirements:
- Use Parquet for nodes/edges; include partition strategy and row group sizing.
- Cite code that defines entities/relations with file+line references.
- Output to workspace/deliverables/generated/graph-ingestion.md.
```

### 1) GraphDB + VectorDB ingestion plan (Judge)

```
Task: Review the ingestion plan for completeness, partitioning correctness, and citation coverage.
Checks:
- Partitions handle large node/edge counts.
- Parquet usage is clear (schemas, row groups).
- Every key entity/relationship has a citation.
Return a verdict and required corrections.
```

### 1) Ubiquitous language (Generator)

```
Task: Extract ubiquitous language and a canonical model from the legacy code.
Requirements:
- Use citations for each term and canonical model element.
- Mark any "LLM-informed" items explicitly.
- Output to workspace/deliverables/generated/ubiquitous-language.md.
```

### 1) Ubiquitous language (Judge)

```
Task: Review ubiquitous language for accuracy, coverage, and citations.
Checks:
- Terms trace to code.
- Canonical model is complete and cited.
Return corrections and missing items.
```

### 2) BRD (Generator)

```
Task: Derive business requirements from legacy code behavior.
Requirements:
- Use citations for each requirement.
- Mark any "LLM-informed" requirements explicitly.
- Output to workspace/deliverables/generated/brd.md.
```

### 2) BRD (Judge)

```
Task: Review BRD for accuracy, scope, and citations.
Checks:
- Requirements trace to code.
- LLM-informed items are marked.
Return corrections and missing items.
```

### 3) BDD Gherkin features + tests (Generator)

```
Task: Generate Gherkin features and Reqnroll tests aligned to the BRD and ubiquitous language.
Requirements:
- Each scenario cites code paths implementing the behavior.
- Output to workspace/deliverables/generated/features/*.feature and workspace/deliverables/generated/tests/.
```

### 3) BDD Gherkin features + tests (Judge)

```
Task: Validate Gherkin features and tests for traceability.
Checks:
- Scenarios map to real behaviors in code.
- Tests align to feature scenarios.
Return corrections and missing citations.
```

### 4) Bounded contexts (Generator)

```
Task: Identify bounded contexts and DDD building blocks.
Requirements:
- Use code-based citations for context boundaries and aggregates.
- Output to workspace/deliverables/generated/bounded-contexts.md.
```

### 4) Bounded contexts (Judge)

```
Task: Validate bounded context boundaries and DDD consistency.
Checks:
- Context separation justified by code dependencies.
- Aggregates/entities are consistent with usage.
Return corrections and gaps.
```

### 5) .NET 8 Clean Architecture rewrite (Generator)

```
Task: Produce a Clean Architecture .NET 8 design spec (no code yet).
Requirements:
- Structure by bounded context.
- Map legacy behaviors to new services and APIs with citations.
- Mark any "LLM-informed" improvements.
- Output to workspace/deliverables/generated/src/README.md (design spec only).
- Produce a coverage report at workspace/deliverables/generated/coverage-report.md using Neo4j, Qdrant, and the citation index.
 - Coverage formulas:
   - File coverage % = cited legacy files / total legacy files
   - Entrypoint coverage % = cited entrypoints / total entrypoints
   - API coverage % = cited API entrypoints / total API entrypoints
   - Class coverage % = cited classes / total classes
   - Method coverage % = cited methods / total methods
   - Qdrant evidence coverage % = cited items with at least one matching vector hit / total cited items
```

### 5) .NET 8 Clean Architecture rewrite (Judge)

```
Task: Review rewrite design for DDD/BDD compliance and parity.
Checks:
- Interfaces and layers are Clean Architecture compliant.
- Behavior parity to legacy code is documented with citations.
Return corrections and gaps.
```

### 6) Test results (Generator)

```
Task: Compile and run integration, performance, and security testing.
Requirements:
- Provide evidence for each test category.
- Output to workspace/deliverables/generated/tests/ (report) and reference workspace/deliverables/generated/src/.
```

### 6) Test results (Judge)

```
Task: Validate testing evidence and deployment readiness statements.
Checks:
- Integration, performance, and security tests are documented.
- Results are supported by evidence.
Return corrections and missing coverage.
```

### Optional: MCP options (Generator)

```
Task: Provide MCP server connectivity options (stdio + HTTP).
Requirements:
- Include required configuration and usage for both.
- Cite any relevant legacy config if applicable.
- Output to workspace/deliverables/generated/mcp-options.md.
```

### Optional: MCP options (Judge)

```
Task: Validate MCP options for completeness and correctness.
Checks:
- Both stdio and HTTP options provided.
- Steps are actionable and clear.
Return corrections.
```

### 6) API mapping and coverage (Generator)

```
Task: Produce a complete old-to-new API mapping.
Requirements:
- For each legacy endpoint, document request/response shapes with citations.
- For each new endpoint, document request/response shapes with citations.
- Map old -> new endpoints and note splits/merges/deprecations.
- Call out new endpoints introduced by bounded contexts.
- Provide coverage summary (mapped/pending/dropped).
- Output to workspace/deliverables/generated/api-mapping.md.
```

### 6) API mapping and coverage (Judge)

```
Task: Validate mapping completeness and traceability.
Checks:
- Every legacy endpoint appears in the mapping or is explicitly dropped.
- Request/response shapes have citations.
- New endpoints are justified by bounded contexts.
Return corrections and missing coverage.
```

