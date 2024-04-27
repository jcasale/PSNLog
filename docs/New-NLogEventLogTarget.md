---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogEventLogTarget

## SYNOPSIS

Creates a Windows Event Log target.

## DESCRIPTION

The New-NLogEventLogTarget cmdlet creates a Windows Event Log target.

## EXAMPLES

### Example 1: Create an Event Log target.

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogEventLogTarget -Source MySource -Name EventLogTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name EventLogRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger.WithProperty('EventID', 42).Info('Hello World!')
```

This example creates a logger with an Event Log target.