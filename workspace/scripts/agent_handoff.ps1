param(
    [Parameter(Mandatory = $true)]
    [string]$Deliverable,
    [Parameter(Mandatory = $true)]
    [string]$JudgeReport,
    [string]$OutputPath
)

$allowed = @("api-mapping", "brd", "bounded-contexts", "gherkin", "tests", "code")
if ($Deliverable -notin $allowed) {
    throw "Unknown deliverable '$Deliverable'. Allowed: $($allowed -join ', ')"
}

if (-not (Test-Path -Path $JudgeReport)) {
    throw "Judge report not found: $JudgeReport"
}

$content = Get-Content -Path $JudgeReport -Raw
$lines = $content -split "`r?`n"

$start = $null
$startLevel = 0
for ($i = 0; $i -lt $lines.Length; $i++) {
    if ($lines[$i] -match '^(?i)(#{1,6})\s+Generator instructions\b') {
        $start = $i + 1
        $startLevel = $matches[1].Length
        break
    }
}

if ($null -eq $start) {
    throw "No 'Generator instructions' heading found in $JudgeReport"
}

$end = $lines.Length - 1
for ($i = $start; $i -lt $lines.Length; $i++) {
    if ($lines[$i] -match '^(#{1,6})\s+' -and $matches[1].Length -le $startLevel) {
        $end = $i - 1
        break
    }
}

if ($end -lt $start) {
    throw "Generator instructions section is empty in $JudgeReport"
}

$section = $lines[$start..$end]
while ($section.Count -gt 0 -and $section[0].Trim() -eq "") {
    $section = $section[1..($section.Count - 1)]
}
while ($section.Count -gt 0 -and $section[$section.Count - 1].Trim() -eq "") {
    $section = $section[0..($section.Count - 2)]
}

if ($section.Count -eq 0) {
    throw "Generator instructions section is empty in $JudgeReport"
}

$handoffDir = Join-Path $PSScriptRoot "..\\agents\\handoffs"
New-Item -ItemType Directory -Force -Path $handoffDir | Out-Null

if (-not $OutputPath) {
    $OutputPath = Join-Path $handoffDir "$Deliverable.md"
}

$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
$out = @(
    "# Handoff: $Deliverable",
    "",
    "Generated: $timestamp",
    "",
    "## Generator instructions",
    ""
) + $section

$out | Set-Content -Path $OutputPath -Encoding ascii
Write-Host "Wrote handoff: $OutputPath"
