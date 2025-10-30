<#!
 .SYNOPSIS
  Builds every .csproj in the repository (excluding bin/obj) sequentially and records failures.

 .OUTPUT FILES (overwritten each run, all under script folder build-logs/)
  build-logs/                - Per-project full build logs (only for failures by default, or all with -AllLogs)
  build-logs/Build_Summary.txt          - High-level counts
  build-logs/Build_Failures.txt         - List of failing project full paths
  build-logs/Build_Failure_Details.txt  - Tail (last N lines) of each failing log for quick triage
  build-logs/Build_Results.csv          - CSV of Project, Status, DurationSeconds, LogPath

 .PARAMETERS
  -AllLogs    Generate logs also for successful builds.
  -TailLines  How many lines from end of failing log to include (default 40).
  -SkipClean  Skip deleting existing build-logs folder.
  -Root       Optional explicit root folder to scan (defaults to parent directory of script folder)
#>
param(
    [switch]$AllLogs,
    [int]$TailLines = 40,
    [switch]$SkipClean,
    [string]$Root
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# $scriptDir is where this script resides (e.g. repoRoot\maintenance)
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
# $repoRoot is the parent folder of the script directory unless explicitly overridden
$repoRoot = if([string]::IsNullOrWhiteSpace($Root)) { Split-Path -Parent $scriptDir } else { (Resolve-Path $Root).Path }

Write-Host "Script directory: $scriptDir" -ForegroundColor DarkGray
Write-Host "Repository root: $repoRoot" -ForegroundColor DarkGray

$logDir = Join-Path $scriptDir 'build-logs'
if(-not $SkipClean -and (Test-Path $logDir)) { Remove-Item $logDir -Recurse -Force }
if(-not (Test-Path $logDir)) { New-Item -ItemType Directory -Path $logDir | Out-Null }

Write-Host "Scanning for projects under $repoRoot ..." -ForegroundColor Cyan
# Explicit path to repo root so the script can live in a subfolder
$projects = Get-ChildItem -Path $repoRoot -Recurse -Filter *.csproj | Where-Object { $_.FullName -notmatch '\\(bin|obj)\\' } | Sort-Object FullName
Write-Host ("Found {0} projects" -f $projects.Count) -ForegroundColor Cyan

$fail = @()
$success = @()
$resultRows = @()
$failureDetails = @()

$swTotal = [System.Diagnostics.Stopwatch]::StartNew()
$index = 0
foreach($proj in $projects){
    $index++
    $rel = Resolve-Path -Relative $proj.FullName
    Write-Host ('['+$index+'/'+$($projects.Count)+'] Building '+$rel)
    $projWatch = [System.Diagnostics.Stopwatch]::StartNew()
    $safeName = ($proj.FullName -replace '[:\\/]','_')
    $logPath = Join-Path $logDir ($safeName + '.log')
    # Build, capturing output
    & dotnet build "$($proj.FullName)" -nologo 2>&1 | Tee-Object -FilePath $logPath | Out-Null
    $exit = $LASTEXITCODE
    $projWatch.Stop()
    if($exit -eq 0){
        $success += $proj.FullName
        if(-not $AllLogs){ Remove-Item $logPath -ErrorAction Ignore }
        $logValue = ''
        if(Test-Path $logPath){ $logValue = $logPath }
        $resultRows += [PSCustomObject]@{ Project=$proj.FullName; Status='Success'; DurationSeconds=[Math]::Round($projWatch.Elapsed.TotalSeconds,2); LogPath=$logValue }
    } else {
        $fail += $proj.FullName
        $tail = Get-Content $logPath -Tail $TailLines
        $failureDetails += 'PROJECT: '+$proj.FullName
        $failureDetails += $tail
        $failureDetails += ('--- END ('+$projWatch.Elapsed.TotalSeconds.ToString('0.00')+'s) ---')
        $resultRows += [PSCustomObject]@{ Project=$proj.FullName; Status='Fail'; DurationSeconds=[Math]::Round($projWatch.Elapsed.TotalSeconds,2); LogPath=$logPath }
    }
}
$swTotal.Stop()

# Outputs go to logDir (script folder/build-logs)
$summaryPath = Join-Path $logDir 'Build_Summary.txt'
$failPath = Join-Path $logDir 'Build_Failures.txt'
$failDetailsPath = Join-Path $logDir 'Build_Failure_Details.txt'
$resultsCsvPath = Join-Path $logDir 'Build_Results.csv'

"Total=$($projects.Count)`nSucceeded=$($success.Count)`nFailed=$($fail.Count)`nElapsedSeconds=$([Math]::Round($swTotal.Elapsed.TotalSeconds,2))" | Set-Content $summaryPath
$fail -join [Environment]::NewLine | Set-Content $failPath
$failureDetails -join [Environment]::NewLine | Set-Content $failDetailsPath
$resultRows | Export-Csv -NoTypeInformation -Path $resultsCsvPath

Write-Host ("Build complete. Success={0} Fail={1} Elapsed={2:n2}s" -f $success.Count,$fail.Count,$swTotal.Elapsed.TotalSeconds) -ForegroundColor Yellow
Write-Host "Summary: $summaryPath" -ForegroundColor DarkGray
if($fail.Count -gt 0){
    Write-Host "First 10 failures:" -ForegroundColor Red
    $fail | Select-Object -First 10 | ForEach-Object { Write-Host '  ' $_ }
    Write-Host "Failure list: $failPath" -ForegroundColor Red
}

exit 0