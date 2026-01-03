# MCP Server Endpoints (Discovery Guide)

## Server identity

- Name: `graph-vector-mcp`
- Transports: HTTP, stdio
- Purpose: expose Neo4j and Qdrant query capabilities and prompt retrieval for LLM use.
- Migration policy: all migration outputs must be generated through MCP + LLM combined workflows with generator/judge agents and human approval.
- Prompts are derived from agent instructions in `.github/agents` (see `Prompt-Generator.md` and `Prompt-Judge.md`) and exposed via `list_prompts`/`get_prompt`.

## JSON-RPC methods (MCP-compatible)

### initialize

MCP handshake response.

Request:
```json
{"jsonrpc":"2.0","id":0,"method":"initialize","params":{}}
```

Response:
```json
{"jsonrpc":"2.0","id":0,"result":{"protocolVersion":"2024-11-05","serverInfo":{"name":"graph-vector-mcp","version":"0.1"},"capabilities":{"tools":{},"prompts":{}}}}
```

### tools/list

Return MCP tool descriptors.

Request:
```json
{"jsonrpc":"2.0","id":1,"method":"tools/list","params":{}}
```

Response:
```json
{"jsonrpc":"2.0","id":1,"result":{"tools":[{"name":"neo4j_query","description":"Run a Cypher query and return records.","inputSchema":{"type":"object","properties":{"cypher":{"type":"string"},"params":{"type":"object"}},"required":["cypher"]}}]}}
```

### tools/call

Invoke a tool by name.

Request:
```json
{"jsonrpc":"2.0","id":2,"method":"tools/call","params":{"name":"neo4j_query","arguments":{"cypher":"MATCH (n) RETURN n LIMIT 1"}}}
```

Response:
```json
{"jsonrpc":"2.0","id":2,"result":{"content":[{"type":"text","text":"{\"records\":[{\"n\":{}}]}"}]}}
```

### list_tools (legacy)

Returns the server name and available tools.

Request:
```json
{"jsonrpc":"2.0","id":1,"method":"list_tools","params":{}}
```

Response:
```json
{
  "jsonrpc":"2.0",
  "id":1,
  "result":{
    "server_name":"graph-vector-mcp",
    "tools":[
      {"name":"neo4j_query","description":"Run a Cypher query and return records."},
      {"name":"qdrant_scroll","description":"Scroll Qdrant points with optional filter."},
      {"name":"qdrant_search","description":"Search Qdrant by vector with optional filter."},
      {"name":"list_prompts","description":"List available system prompts."},
      {"name":"get_prompt","description":"Get a system prompt by role name."}
    ]
  }
}
```

### neo4j_query

Run a Cypher query and return records.

Request:
```json
{
  "jsonrpc":"2.0",
  "id":2,
  "method":"neo4j_query",
  "params":{
    "cypher":"MATCH (n:Node {type:'File'}) RETURN n.name AS name LIMIT $limit",
    "params":{"limit":5}
  }
}
```

Response:
```json
{"jsonrpc":"2.0","id":2,"result":{"records":[{"name":"Example"}]}}
```

### qdrant_scroll

Scroll Qdrant points with optional filter.

Request:
```json
{
  "jsonrpc":"2.0",
  "id":3,
  "method":"qdrant_scroll",
  "params":{
    "collection":"code_vectors",
    "limit":10,
    "offset":0,
    "filter":null
  }
}
```

Response:
```json
{
  "jsonrpc":"2.0",
  "id":3,
  "result":{
    "points":[{"id":"1","payload":{"sourceFile":"...","sourceLine":1}}],
    "next_offset":10
  }
}
```

### qdrant_search

Search Qdrant by vector with optional filter.

Request:
```json
{
  "jsonrpc":"2.0",
  "id":4,
  "method":"qdrant_search",
  "params":{
    "collection":"code_vectors",
    "vector":[0.01,0.02,0.03],
    "limit":5,
    "filter":null
  }
}
```

Response:
```json
{
  "jsonrpc":"2.0",
  "id":4,
  "result":{
    "points":[{"id":"1","score":0.99,"payload":{"sourceFile":"...","sourceLine":1}}]
  }
}
```

### list_prompts (legacy)

List available system prompt roles.

Request:
```json
{"jsonrpc":"2.0","id":5,"method":"list_prompts","params":{}}
```

Response:
```json
{"jsonrpc":"2.0","id":5,"result":{"prompts":["Generator","Judge"]}}
```

### get_prompt (legacy)

Return a system prompt by role name.

Request:
```json
{"jsonrpc":"2.0","id":6,"method":"get_prompt","params":{"role":"Generator"}}
```

Response:
```json
{"jsonrpc":"2.0","id":6,"result":{"role":"Generator","content":"..."}}
```

### prompts/list

List available system prompt roles.

Request:
```json
{"jsonrpc":"2.0","id":7,"method":"prompts/list","params":{}}
```

Response:
```json
{"jsonrpc":"2.0","id":7,"result":{"prompts":[{"name":"Generator","description":"Generator system prompt"}]}}
```

### prompts/get

Return a system prompt by name.

Request:
```json
{"jsonrpc":"2.0","id":8,"method":"prompts/get","params":{"name":"Generator"}}
```

Response:
```json
{"jsonrpc":"2.0","id":8,"result":{"prompt":{"name":"Generator","content":"..."}}}
```

## Transport options

### HTTP

- Start server:
  - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\mcp_server\mcp_server.py --transport http --host 127.0.0.1 --port 8765 --server-name graph-vector-mcp`
- POST JSON-RPC requests to `http://127.0.0.1:8765`.
- SSE stream is available via GET `http://127.0.0.1:8765/` for MCP clients that expect server events.
- Script helper: `c:\Users\shara\code\migration\workspace\scripts\start_mcp_http.ps1`

### stdio

- Start server (stdio):
  - `c:\Users\shara\code\migration\workspace\.venv\Scripts\python.exe c:\Users\shara\code\migration\workspace\mcp_server\mcp_server.py --transport stdio --server-name graph-vector-mcp`
- Example MCP config (stdio):
```json
{
  "servers": {
    "mcp-migration-stdio": {
      "type": "stdio",
      "command": "c:/Users/shara/code/migration/workspace/.venv/Scripts/python.exe",
      "args": ["c:/Users/shara/code/migration/workspace/mcp_server/mcp_server.py", "--transport", "stdio", "--server-name", "graph-vector-mcp"]
    }
  }
}
```

## Copilot Chat integration file

- Config file: `c:\Users\shara\code\migration\workspace\deliverables\generated\copilot-mcp.json`
- Includes the HTTP server entry under `mcpServers` with name `mcp-migration`.
- VS Code MCP config: `c:\Users\shara\code\migration\.vscode\mcp.json` with the `mcp-migration` server name.

## Qdrant collections

- `code_vectors`: file-level embeddings.
- `code_comments`: extracted source comments.
- `generated_comments`: generated summary comments (heuristic source).
- `stored_procedures`: stored procedure definitions.
