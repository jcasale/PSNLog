---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Get-NLogLoggingConfiguration

## SYNOPSIS

Gets the current logging configuration.

## DESCRIPTION

The Get-NLogLoggingConfiguration cmdlet gets the current configuration.

The cmdlet will throw if a configuration is not found.

## EXAMPLES

### Example 1: Gets the previously set configuration from the static `NLog.LogManager.Configuration` property.

```powershell
$configuration = Get-NLogLoggingConfiguration
```

This example gets the previously set configuration from the static `NLog.LogManager.Configuration` property.