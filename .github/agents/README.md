# Copilot Chat Agents

## Order of Use

Use the Generator first, then the Judge for the same deliverable:

1. Agent-UL-Gen-1 -> Agent-UL-Judge-1
2. Agent-BRD-Gen-2 -> Agent-BRD-Judge-2
3. Agent-Gherkin-Gen-3 -> Agent-Gherkin-Judge-3
4. Agent-BC-Gen-4 -> Agent-BC-Judge-4
5. Agent-Map-Gen-5 -> Agent-Map-Judge-5
6. Agent-Code-Gen-6 -> Agent-Code-Judge-6
7. Agent-Test-Gen-7 -> Agent-Test-Judge-7

## How to Use

1. Start the MCP server:
   `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\mcp_server\mcp_server.py --transport http --host 127.0.0.1 --port 8765 --server-name graph-vector-mcp`
2. Open Copilot Chat in VS Code.
3. Select the agent by name (e.g., `Agent-BRD-Gen-2`).
4. Provide a concrete request for that deliverable (see prompts below).
5. After the Generator completes, run the matching Judge.

## Sequential Guidance (Gate-Driven)

Follow these steps in order. Copilot should always use outputs from the previous step. If a deliverable is missing, stop and ask the user to run the previous step using the specific agent listed below. Do not start a new step until the matching Judge has run at least once for the prior step.

1. Ubiquitous Language
   - Generator: `Agent-UL-Gen-1`
   - Judge: `Agent-UL-Judge-1`
   - Deliverable: `workspace/deliverables/generated/ubiquitous-language.md`
   - Gate: Judge has reviewed at least once and output saved.
2. BRD
   - Generator: `Agent-BRD-Gen-2`
   - Judge: `Agent-BRD-Judge-2`
   - Deliverable: `workspace/deliverables/generated/brd.md`
   - Gate: Judge has reviewed at least once and output saved.
3. Gherkin Features + Tests
   - Generator: `Agent-Gherkin-Gen-3`
   - Judge: `Agent-Gherkin-Judge-3`
   - Deliverables:
     - `workspace/deliverables/generated/features/*.feature`
     - `workspace/deliverables/generated/tests/`
   - Gate: Judge has reviewed at least once and output saved.
4. Bounded Contexts + DDD Specs
   - Generator: `Agent-BC-Gen-4`
   - Judge: `Agent-BC-Judge-4`
   - Deliverable: `workspace/deliverables/generated/bounded-contexts.md`
   - Gate: Judge has reviewed at least once and output saved.
5. API Mapping + Coverage
   - Generator: `Agent-Map-Gen-5`
   - Judge: `Agent-Map-Judge-5`
   - Deliverable: `workspace/deliverables/generated/api-mapping.md`
   - Gate: Judge has reviewed at least once and output saved.
6. Forward Engineering (Code)
   - Generator: `Agent-Code-Gen-6`
   - Judge: `Agent-Code-Judge-6`
   - Deliverables:
     - `workspace/deliverables/generated/src/`
     - `workspace/deliverables/generated/coverage-report.md`
   - Gate: Judge has reviewed at least once and output saved.
7. Test Results (Integration/Performance/Security)
   - Generator: `Agent-Test-Gen-7`
   - Judge: `Agent-Test-Judge-7`
   - Deliverables:
     - `workspace/deliverables/generated/tests/`
     - `workspace/deliverables/generated/src/`
   - Gate: Judge has reviewed at least once and output saved.

## Generator + Judge Iteration Loop

Generators must run a 2-iteration loop with the matching Judge:
1. Generate and save output.
2. Run the Judge and collect its "Generator instructions".
3. Apply the instructions and regenerate.
4. Run the Judge again and apply any remaining fixes.

## Best Practices per Agent

### Ubiquitous Language (UL)
- Start from legacy code terms; keep business language only.
- Use the UL term catalog template and produce UL graph artifacts.
- Cross-check terms and citations with the full citation index.
- Batch markdown must use `# <TermName>`, include `## Term Catalog`, and include one `### Term: <TermName>` entry so the assembler can merge sections without duplicating headers.
- Complete all batch markdown files before generating any Parquet output.
- Final markdown assembly:
  - `workspace\.venv\Scripts\python.exe workspace\scripts\assemble_ul_from_parquet.py --parquet-root "c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet\ul-sections" --output "c:\Users\shara\code\migration\workspace\deliverables\generated\ubiquitous-language.md"`

### BRD
- Write for Business Analysts and Domain Experts; avoid technical terms.
- Derive requirements from UL and legacy behavior evidence.
- Flag all LLM-informed items explicitly.

### Gherkin + Tests
- Keep scenarios consistent with BRD and UL terms.
- Ensure every scenario has evidence and a matching test.
- Use the Reqnroll template for tests and keep naming consistent.

### Bounded Contexts + DDD
- Partition by context and module to avoid cross-context leakage.
- Align aggregates/entities to UL terms and Gherkin scenarios.
- Cite boundaries using Neo4j relationships and file evidence.

### API Mapping
- Compare API mapping against the citation index for coverage.
- Include legacy endpoints (ASPX/ASMX/WCF/ASHX) and note gaps.
- Provide a coverage summary and highlight unmapped endpoints.

### Forward Engineering (Code)
- Use all prior deliverables and the API mapping as inputs.
- Produce the coverage report with the required formulas.
- Keep code outline consistent with bounded contexts and BRD.

### Test Results
- Run integration, performance, and security tests.
- Report blockers and readiness with evidence references.
- Ensure results align with features and code outputs.

## Explicit Prompts per Agent

Always review Neo4j labels and relationship types before querying, and prefer filtering by `type` in queries.
Follow the numbered order below.

### 1) ubiquitous-language
- Agent-UL-Gen-1: Generate ubiquitous language from MCP evidence using the term catalog template. Populate all required term fields. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single deliverable. Ensure all graph nodes are considered. Review all available artifacts first; ask targeted questions only if needed. Audience: Business Analyst and Domain Expert; avoid implementation details.
- Agent-UL-Judge-1: Review ubiquitous language for missing/weak citations and any inferred content, and validate that every term includes the required fields. Ensure tone is business-focused and non-technical.

### 2) brd
- Agent-BRD-Gen-2: Generate the BRD from MCP evidence using the BRD template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single BRD. Ensure all graph nodes are considered. Review all available artifacts first; ask targeted questions only if needed. Audience: Business Analyst and Domain Expert; avoid technical terms.
- Agent-BRD-Judge-2: Review the BRD for missing/weak citations and any inferred content. Ensure tone is business-focused and non-technical.

### 3) gherkin
- Agent-Gherkin-Gen-3: Generate Gherkin feature files from MCP evidence using the workflow header, and generate Reqnroll tests using the Reqnroll template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a complete set of features and tests. Ensure all graph nodes are considered. Review all available artifacts first; ask targeted questions only if needed.
- Agent-Gherkin-Judge-3: Review the Gherkin features for missing/weak citations and any inferred content.

### 4) bounded-contexts
- Agent-BC-Gen-4: Generate bounded contexts from MCP evidence using the bounded-contexts template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single deliverable. Ensure all graph nodes are considered. Review all available artifacts first; ask targeted questions only if needed.
- Agent-BC-Judge-4: Review bounded contexts for missing/weak citations and any inferred content.

### 5) api-mapping
- Agent-Map-Gen-5: Generate the API mapping from MCP evidence using the api-mapping template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single mapping. Ensure all graph nodes are considered. Review all available artifacts first; ask targeted questions only if needed.
- Agent-Map-Judge-5: Review the API mapping for missing/weak citations and any inferred content.

### 6) code
- Agent-Code-Gen-6: Generate the code deliverable outline from MCP evidence using the project README template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single outline. Ensure all graph nodes are considered. Review all available artifacts first; ask targeted questions only if needed.
- Agent-Code-Judge-6: Review the code deliverable for missing/weak citations and any inferred content.

### 7) tests
- Agent-Test-Gen-7: Compile code and run integration tests using existing features and test assets. Report deployment readiness and blockers.
- Agent-Test-Judge-7: Review test execution evidence and readiness statement for accuracy.

## Agent Input Map

All paths refer to `workspace/deliverables/generated` unless noted.

| Agent | Inputs (documents + MCP) | Outputs |
| --- | --- | --- |
| Agent-UL-Gen-1 | MCP (Neo4j + Qdrant) | `ubiquitous-language.md` |
| Agent-UL-Judge-1 | `ubiquitous-language.md` + MCP | Review notes |
| Agent-BRD-Gen-2 | `ubiquitous-language.md` + MCP | `brd.md` |
| Agent-BRD-Judge-2 | `brd.md`, `ubiquitous-language.md` + MCP | Review notes |
| Agent-Gherkin-Gen-3 | `brd.md`, `ubiquitous-language.md` + MCP | `features/*.feature`, `tests/` |
| Agent-Gherkin-Judge-3 | `features/*.feature`, `tests/` + MCP | Review notes |
| Agent-BC-Gen-4 | `brd.md`, `ubiquitous-language.md`, `features/*.feature`, `tests/` + MCP | `bounded-contexts.md` |
| Agent-BC-Judge-4 | `bounded-contexts.md` + MCP | Review notes |
| Agent-Map-Gen-5 | `bounded-contexts.md`, `features/*.feature`, `tests/` + MCP | `api-mapping.md` |
| Agent-Map-Judge-5 | `api-mapping.md` + MCP | Review notes |
| Agent-Code-Gen-6 | `brd.md`, `bounded-contexts.md`, `ubiquitous-language.md`, `features/*.feature`, `tests/`, `api-mapping.md` + MCP | `src/**`, `coverage-report.md` |
| Agent-Code-Judge-6 | `src/**`, `coverage-report.md` + MCP | Review notes |
| Agent-Test-Gen-7 | `src/`, `features/*.feature`, `tests/` | Compile + integration test report |
| Agent-Test-Judge-7 | Test report + `src/` | Review notes |

## Notes

- Agents use MCP prompts and tools (`prompts/get`, `tools/call`) for evidence-based work.
- Deliverable targets and templates are listed in each agent file.
- Judges should include a "Generator instructions" section with actionable fixes for the matching Generator.
- All generated outputs live under `workspace/deliverables/generated`. Delete `workspace/deliverables` to reset all outputs.
- Build the full citation index with `--limit 0 --file-limit 0 --rel-limit 0` before running agents.
- Before constructing Neo4j queries, review available node types and relationship types.
- Query requirements (applies to all agents):
  - Use Neo4j for structural relationships and Qdrant for semantic similarity.
  - State which Neo4j database and which Qdrant collections were used, and why.
  - Log every `neo4j_query` and `qdrant_search`/`qdrant_scroll` call and summarize their purpose.

## Scripted Handoff Workflow

Use this when you want the Judge output to automatically feed the Generator.
1. Save the Judge response to a file (example: `C:\temp\brd-judge.md`).
2. Run the handoff script:
   `powershell -File workspace\scripts\agent_handoff.ps1 -Deliverable brd -JudgeReport C:\temp\brd-judge.md`
3. The script writes: `workspace/agents/handoffs/brd.md`
4. Run the matching Generator and instruct it to read the handoff file before continuing.

## Generator Report Workflow

After a Generator finishes, it should write a brief report to:
`workspace/agents/handoffs/<deliverable>-gen.md`
The matching Judge should read that report before reviewing.
