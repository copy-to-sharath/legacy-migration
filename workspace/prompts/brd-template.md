# Business Requirements Document (BRD)

## Agent workflow

{agent_header}

## Scope summary

This BRD describes a .NET 8 rewrite of the legacy solution. Requirements are derived from graph/vector sources via MCP only.
Detected bounded contexts: {total_contexts}.

## Stakeholders (evidence-driven)

Stakeholders will be confirmed by human review. Evidence is listed per context below.

## Business goals (evidence-driven)

- Preserve and expose workflows for {total_contexts} bounded contexts.
- Provide REST-based APIs and clean architecture in the .NET 8 rewrite.

## In-scope legacy modules (MCP-derived citations)

{in_scope_modules}

## Functional requirements (FR)

{functional_requirements}

## Non-functional requirements (LLM-inferred)

- Scalability: support high-volume datasets and requests.
- Observability: structured logs for traceability.
- Compatibility: .NET 8, clean architecture, DDD boundaries.

LLM inference note: non-functional requirements are derived from migration goals and must be confirmed by humans.

## Judge review notes (pending)

- Verify FR items against MCP-derived citations.
- Confirm LLM-inferred statements are labeled.
