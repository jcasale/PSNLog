---
external help file: PSNLog.dll-help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogBasicLogger

## SYNOPSIS

Creates a basic logger with a common configuration.

## DESCRIPTION

The New-NLogBasicLogger cmdlet creates a basic logger with a common configuration.

This cmdlet performs the following functions:

  * Creates a new NLog configuration with a console and file target.
  * Assigns the new configuration to the static NLog logging configuration.
  * Creates a new NLog logger
  * Returns the logger instance.

## EXAMPLES

### ----------- Example 1: Create a basic logger -----------

```powershell
$logger = New-NLogBasicLogger -Name MyLogger -Path x:/path/application.log
```

This command creates a new logger with the MyLogger name and writes log entries to the console and indicated path.