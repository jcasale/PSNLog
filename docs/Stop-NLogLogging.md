---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Stop-NLogLogging

## SYNOPSIS

Stops logging.

## DESCRIPTION

The Stop-NLogLogging cmdlet stops logging and clears the current logging configuration.

## EXAMPLES

### Example 1: Dispose all targets, and shuts logging down.

```powershell
Stop-NLogLogging
```

This example dispose all targets, and shuts logging down. It assumes the configuration instance was set to the static `NLog.LogManager.Configuration` property.