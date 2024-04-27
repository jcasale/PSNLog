---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogLoggingRule

## SYNOPSIS

Creates a logging rule target.

## DESCRIPTION

The New-NLogLoggingRule cmdlet creates a logging rule.

## EXAMPLES

### Example 1: Create a logging rule.

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogColoredConsoleTarget -Name ConsoleTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name ConsoleRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
```

This example creates a rule for a console target and adds it to the specified configuration.