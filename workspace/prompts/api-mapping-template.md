# Legacy-to-New API Mapping and Coverage

## Agent workflow

{agent_header}

## Legacy endpoint inventory (graph-derived via MCP)

Note: request/response shapes are inferred from endpoint names and common WebForms patterns.

| Legacy endpoint | Type | Proposed REST endpoint | Context | Evidence |
| --- | --- | --- | --- | --- |
{legacy_rows}

## Coverage summary

{coverage_summary}

## Vector sample citations (Qdrant, via MCP)

{vector_citations}

## Judge review notes (pending)

- Validate endpoint mapping rules against bounded contexts.
- Confirm any Legacy endpoints are routed to appropriate contexts.
- Approve coverage summary after human signoff.
