---
title: Copilot Chat Agents
---

# Copilot Chat Agents

## Order of use

Use the Generator first, then the Judge for the same deliverable:

1. Agent-Map-Gen -> Agent-Map-Judge
2. Agent-BRD-Gen -> Agent-BRD-Judge
3. Agent-Gherkin-Gen -> Agent-Gherkin-Judge
4. Agent-Test-Gen -> Agent-Test-Judge
5. Agent-Code-Gen -> Agent-Code-Judge

## How to use

1. Start the MCP server:
   `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\mcp_server\mcp_server.py --transport http --host 127.0.0.1 --port 8765 --server-name graph-vector-mcp`
2. Open Copilot Chat in VS Code.
3. Select the agent by name (for example, `Agent-BRD-Gen`).
4. Provide a concrete request for that deliverable (see prompts below).
5. After the Generator completes, run the matching Judge.

## Generator + Judge iteration loop

Generators must run a 2-iteration loop with the matching Judge:

1. Generate and save output.
2. Run the Judge and collect its "Generator instructions".
3. Apply the instructions and regenerate.
4. Run the Judge again and apply any remaining fixes.

## Explicit prompts per agent

### api-mapping
- Agent-Map-Gen: "Generate the API mapping from MCP evidence using the api-mapping template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single mapping. Ensure all graph nodes are considered. Do not ask questions; state assumptions and proceed."
- Agent-Map-Judge: "Review the API mapping for missing/weak citations and any inferred content."

### brd
- Agent-BRD-Gen: "Generate the BRD from MCP evidence using the BRD template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single BRD. Ensure all graph nodes are considered. Do not ask questions; state assumptions and proceed."
- Agent-BRD-Judge: "Review the BRD for missing/weak citations and any inferred content."

### gherkin
- Agent-Gherkin-Gen: "Generate Gherkin feature files from MCP evidence using the workflow header. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a complete set of features. Ensure all graph nodes are considered. Do not ask questions; state assumptions and proceed."
- Agent-Gherkin-Judge: "Review the Gherkin features for missing/weak citations and any inferred content."

### tests
- Agent-Test-Gen: "Generate Reqnroll test steps from MCP evidence using the Reqnroll template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a complete test suite. Ensure all graph nodes are considered. Do not ask questions; state assumptions and proceed."
- Agent-Test-Judge: "Review the test steps for missing/weak citations and any inferred content."

### code
- Agent-Code-Gen: "Generate the code deliverable outline from MCP evidence using the project README template. Cover the entire codebase by splitting it into manageable chunks, process each chunk, then merge into a single outline. Ensure all graph nodes are considered. Do not ask questions; state assumptions and proceed."
- Agent-Code-Judge: "Review the code deliverable for missing/weak citations and any inferred content."

## Notes

- Agents use MCP prompts and tools (`prompts/get`, `tools/call`) for evidence-based work.
- Deliverable targets and templates are listed in each agent file.
- Judges should include a "Generator instructions" section with actionable fixes for the matching Generator.

## Scripted handoff workflow

Use this when you want the Judge output to automatically feed the Generator.

1. Save the Judge response to a file (example: `C:\temp\brd-judge.md`).
2. Run the handoff script:
   `powershell -File workspace\scripts\agent_handoff.ps1 -Deliverable brd -JudgeReport C:\temp\brd-judge.md`
3. The script writes: `.github/agents/handoffs/brd.md`
4. Run the matching Generator and instruct it to read the handoff file before continuing.

## Generator report workflow

After a Generator finishes, it should write a brief report to:
`.github/agents/handoffs/<deliverable>-gen.md`

The matching Judge should read that report before reviewing.
