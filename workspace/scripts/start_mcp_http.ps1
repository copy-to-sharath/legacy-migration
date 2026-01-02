param(
    [string]$Host = "127.0.0.1",
    [int]$Port = 8765,
    [string]$ServerName = "graph-vector-mcp"
)

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$python = Join-Path $root ".venv\\Scripts\\python.exe"
$server = Join-Path $root "mcp_server\\mcp_server.py"

if (-not (Test-Path $python)) {
    throw "Python venv not found at $python"
}

if (-not (Test-Path $server)) {
    throw "MCP server not found at $server"
}

& $python $server --transport http --host $Host --port $Port --server-name $ServerName
