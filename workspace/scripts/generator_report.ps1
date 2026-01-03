param(
    [Parameter(Mandatory = $true)]
    [string]$Deliverable,
    [Parameter(Mandatory = $true)]
    [string]$Report
)

$allowed = @("api-mapping", "brd", "bounded-contexts", "gherkin", "tests", "code")
if ($Deliverable -notin $allowed) {
    throw "Unknown deliverable '$Deliverable'. Allowed: $($allowed -join ', ')"
}

$handoffDir = Join-Path $PSScriptRoot "..\\agents\\handoffs"
New-Item -ItemType Directory -Force -Path $handoffDir | Out-Null

$outPath = Join-Path $handoffDir "$Deliverable-gen.md"
$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"

$content = @(
    "# Generator report: $Deliverable",
    "",
    "Generated: $timestamp",
    "",
    "## Summary",
    ""
)

$reportLines = $Report -split "`r?`n"
$content += $reportLines

$content | Set-Content -Path $outPath -Encoding ascii
Write-Host "Wrote generator report: $outPath"
