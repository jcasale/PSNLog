---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Add-NLogTarget

## SYNOPSIS

Adds the specified logging target to the specified configuration.

## DESCRIPTION

The Add-NLogTarget cmdlet adds the specified logging target to the existing collection of targets in the specified configuration.

## EXAMPLES

### Example 1: Add a target to a configuration.

```powershell
$configuration = New-NLogLoggingConfiguration
$consoleTarget = New-NLogColoredConsoleTarget -Name ConsoleTarget
Add-NLogTarget -Target $consoleTarget -Configuration $configuration
```

This example adds a console target to the configuration.