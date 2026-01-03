# Ubiquitous Language (Template)

## Delivery workflow (batch first)

- Generate UL content in small batches and write each batch to Parquet.
- After all batches are complete, assemble the final Markdown deliverable from Parquet.
- The final Markdown follows the sections below.
- Use `workspace\.venv\Scripts\python.exe workspace\scripts\assemble_ul_from_parquet.py` to build the final Markdown in order.
- Store UL section batches under `workspace/deliverables/generated/ul-parquet/ul-sections/`.
- Store UL graph artifacts under `workspace/deliverables/generated/ul-parquet/nodes/` and `workspace/deliverables/generated/ul-parquet/edges/`.

## 1. Bounded Contexts (optional)

List the bounded contexts used in the domain and a short business-facing description for each.

Format:
- Context: <ContextName>
  - Description: <1-2 sentences>
  - Neighbors: <ContextA>, <ContextB>

---

## 2. Term Catalog (required)

Use a simple, repeatable structure so it can live in version control and be referenced in code reviews, story grooming, and modeling sessions.
Keep term names and key attributes close to eventual class and field names.

Each term entry must include:
- Term
- Also known as / Not
- Bounded context
- Short definition
- Core attributes
- Invariants / business rules
- Lifecycle / states
- Example phrases
- Notes

### Term entry format

### Term: <TermName>

- Term: <CanonicalName>
- Also known as / Not:
  - Also: <Synonym1>, <Synonym2>
  - Not: <CommonConfusion1>, <CommonConfusion2>
- Bounded context: <ContextName>
- Short definition: <1-2 sentences, business-facing>
- Core attributes:
  - <AttributeName> (type): <Business meaning>
  - <AttributeName> (type): <Business meaning>
- Invariants / business rules:
  - <Rule in business language>
  - <Rule in business language>
- Lifecycle / states:
  - <StateA> -> <StateB> -> <StateC>
- Example phrases:
  - "<Example sentence domain experts use.>"
  - "<Example sentence domain experts use.>"
- Notes:
  - <Ambiguities, edge cases, or regulatory nuances>

---

## 3. Relationships (optional)

Use this when relationships between terms are important for clarity.

Format:
- Relationship: <TermA> <verb> <TermB>
  - Bounded context: <ContextName>
  - Description: <Business meaning>
  - Cardinality: <1:1|1:N|N:1|N:N>
  - Notes: <Constraints or edge cases>

---

## 4. Events and Workflows (optional)

Format:
- Event: <EventName>
  - Bounded context: <ContextName>
  - Trigger: <What causes the event>
  - Outcome: <Business result>
  - Notes: <Constraints or downstream effects>

---

## 5. Mapping to Implementation (optional)

Briefly map terms to implementation areas (modules, APIs, services) without deep technical detail.

Format:
- Term: <TermName>
  - Code alignment: <Module/namespace/API route>

---

## 6. Notes on Usage

- Keep the artifact lightweight and update it as new language emerges.
- Use the same terms in stories, UI, APIs, and code.
- Flag inferred terms explicitly and justify with citations.

---

## 7. Graph artifacts (generated)

After sections 1-6, generate graph artifacts derived from the UL as Parquet and ingest them into Neo4j.

Parquet output locations:
- `workspace/deliverables/generated/ul-parquet/nodes/`
- `workspace/deliverables/generated/ul-parquet/edges/`

Node schema (Parquet columns, aligned to graph loader):
- `id,type,context,name,description,sourceFile,sourceLine,project,ext,entryKind`

Edge schema (Parquet columns, aligned to graph loader):
- `id,type,context,sourceId,targetId,description`

PyArrow schema (nodes):
```python
pa.schema([
    ("id", pa.string()),
    ("type", pa.string()),
    ("context", pa.string()),
    ("name", pa.string()),
    ("description", pa.string()),
    ("sourceFile", pa.string()),
    ("sourceLine", pa.int64()),
    ("project", pa.string()),
    ("ext", pa.string()),
    ("entryKind", pa.string()),
])
```

PyArrow schema (edges):
```python
pa.schema([
    ("id", pa.string()),
    ("type", pa.string()),
    ("context", pa.string()),
    ("sourceId", pa.string()),
    ("targetId", pa.string()),
    ("description", pa.string()),
])
```

Use stable IDs based on UL names (e.g., `term:<name>`, `relationship:<name>`, `event:<name>`).
Use `context` = `ubiquitous-language` for all UL nodes/edges.

Ingest into Neo4j:
- Run `workspace/scripts/load_graph_vector.py` with `--parquet-root "c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet"` and `--skip-qdrant`.

---

## Parquet-first UL output (batching)

Write UL content to Parquet in small batches before assembling the final Markdown:

Parquet output location:
- `workspace/deliverables/generated/ul-parquet/ul-sections/`

Schema (Parquet columns):
- `batch_id,section,subsection,content,context,sourceFile,sourceLine`

PyArrow schema (ul-sections):
```python
pa.schema([
    ("batch_id", pa.string()),
    ("section", pa.string()),
    ("subsection", pa.string()),
    ("content", pa.string()),
    ("context", pa.string()),
    ("sourceFile", pa.string()),
    ("sourceLine", pa.int64()),
])
```

Batching rules:
- Use one term per batch markdown file.
- Each batch file should include `## Term Catalog` and a single `### Term: <TermName>` entry.
- Each batch must include citations and reference the citation index.
- After all batches are complete, generate `workspace/deliverables/generated/ubiquitous-language.md` from the Parquet content.
