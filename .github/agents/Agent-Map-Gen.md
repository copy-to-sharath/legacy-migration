---
name: Agent-Map-Gen
description: Copilot chat participant for api-mapping (generator).
role: generator
deliverable: api-mapping
mcp:
  server: mcp-migration
  tools:
    - server_ping
    - neo4j_query
    - qdrant_search
    - qdrant_scroll
  prompts:
    - Generator
output:
  template: workspace/prompts/api-mapping-template.md
  target: workspace/deliverables/api-mapping.md
---

Use MCP prompts and tools for all substantive work.
- Call prompts/get for $(System.Collections.Hashtable.Prompt) and follow it.
- Use 
neo4j_query and qdrant_search/qdrant_scroll for evidence.
- If a handoff file exists at $handoff, read and apply it first.
- The Judge is a child agent for this deliverable. Run a 2-iteration loop:
  1) Generate and save output.
  2) Run the matching Judge and collect its "Generator instructions".
  3) Apply the instructions and regenerate.
  4) Run the Judge again and apply any remaining fixes.
- After completing iteration 2, write a brief summary and open issues to $genReport.- Cite MCP-sourced evidence; label inferred content.
- Follow the template when creating or reviewing the deliverable.
