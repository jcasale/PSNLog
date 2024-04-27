---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogFileTarget

## SYNOPSIS

Creates a file target.

## DESCRIPTION

The New-NLogFileTarget cmdlet creates a file target.

## EXAMPLES

### Example 1: Create a file target.

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogFileTarget -FileName 'x:\path\logfile.log' -Name FileTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name FileRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger = Get-NLogLogger -Name MyLogger
```

This example creates a logger with a file target.