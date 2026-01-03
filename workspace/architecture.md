---
title: MCP + Agents Architecture
---

# MCP + Agents Architecture (Swimlane)

```mermaid
flowchart LR
  %% Swimlanes
  subgraph L1[Developer / VS Code]
    A1[User request in VS Code]
    A2[Select Agent (Generator)]
    A3[Review output + Judge report]
    A4[Human approval gate]
  end

  subgraph L2[Agent Runtime (Copilot Chat)]
    B1[Generator agent]
    B2[Judge agent]
    B3[Generator report]
  end

  subgraph L3[MCP Client + Config]
    C1[VS Code MCP config\n.vscode/mcp.json]
    C2[Copilot MCP config\nworkspace/deliverables/generated/copilot-mcp.json]
    C3[MCP client]
  end

  subgraph L4[MCP Server (graph-vector-mcp)]
    D1[initialize / tools/list / prompts/list]
    D2[tools/call: neo4j_query]
    D3[tools/call: qdrant_search / qdrant_scroll]
    D4[prompts/get]
  end

  subgraph L5[Data Stores]
    E1[Neo4j (graph)]
    E2[Qdrant (vector)]
    E3[Parquet + Roslyn index]
  end

  %% Common MCP setup
  A1 --> A2 --> B1
  B1 --> C3
  C1 --> C3
  C2 --> C3
  C3 --> D1 --> D4 --> B1
  B1 --> D2 --> E1
  B1 --> D3 --> E2
  E3 -.-> D2
  E3 -.-> D3

  %% Deliverable sequence with generator/judge loop + gate
  subgraph L6[Deliverables (step-by-step)]
    M1[1) API Mapping Generator\nAgent-Map-Gen-5] --> M2[API Mapping Judge\nAgent-Map-Judge-5]
    M2 --> M3[Human approval gate]
    M3 --> M4[2) BRD Generator\nAgent-BRD-Gen-2]
    M4 --> M5[BRD Judge\nAgent-BRD-Judge-2]
    M5 --> M6[Human approval gate]
    M6 --> M7[3) Gherkin Generator\nAgent-Gherkin-Gen-3]
    M7 --> M8[Gherkin Judge\nAgent-Gherkin-Judge-3]
    M8 --> M9[Human approval gate]
    M9 --> M10[4) Tests Generator\nAgent-Test-Gen-7]
    M10 --> M11[Tests Judge\nAgent-Test-Judge-7]
    M11 --> M12[Human approval gate]
    M12 --> M13[5) Code Generator\nAgent-Code-Gen-6]
    M13 --> M14[Code Judge\nAgent-Code-Judge-6]
    M14 --> M15[Human approval gate]
  end

  %% Wire the deliverable loop to the runtime and user review
  B1 --> M1
  M2 --> B2
  M5 --> B2
  M8 --> B2
  M11 --> B2
  M14 --> B2
  M2 --> A3 --> A4
  M5 --> A3
  M8 --> A3
  M11 --> A3
  M14 --> A3
  A4 -->|approve| M3
  A4 -->|approve| M6
  A4 -->|approve| M9
  A4 -->|approve| M12
  A4 -->|approve| M15
  A4 -->|reject| B1
```

## Flow notes

- Generator uses MCP prompts (`prompts/get`) and evidence tools (`neo4j_query`, `qdrant_search`, `qdrant_scroll`) for deliverables.
- Judge validates citations, inference flags, and completeness, then issues “Generator instructions.”
- Human approval gate is required after judge review before acceptance.
- MCP server exposes tools and prompts; data is backed by Neo4j and Qdrant populated from Roslyn + Parquet ingestion.
