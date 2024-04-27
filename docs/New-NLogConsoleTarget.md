---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogConsoleTarget

## SYNOPSIS

Creates a console target.

## DESCRIPTION

The New-NLogConsoleTarget cmdlet creates a console target.

## EXAMPLES

### Example 1: Create a console target.

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogConsoleTarget -Name ConsoleTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name ConsoleRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger = Get-NLogLogger -Name MyLogger
```

This example creates a logger with a console target.