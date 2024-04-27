---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Add-NLogLoggingConfiguration

## SYNOPSIS

Adds the specified configuration to the current logging configuration.

## DESCRIPTION

The Add-NLogLoggingConfiguration cmdlet adds the specified configuration instance to the static `NLog.LogManager.Configuration` property.

The cmdlet will throw if an existing configuration is already set. Use the Stop-NLogLogging cmdlet to shut down logging before setting a new configuration.

## EXAMPLES

### Example 1: Add a configuration to the static `NLog.LogManager.Configuration` property.

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
Add-NLogLoggingConfiguration $configuration
```

This example creates a basic configuration with a console target and adds it to the static `NLog.LogManager.Configuration` property.