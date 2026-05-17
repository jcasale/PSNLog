---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: Stop-NLogLogging
---

# Stop-NLogLogging

## SYNOPSIS

Stops logging.

## SYNTAX

### __AllParameterSets

```
Stop-NLogLogging [<CommonParameters>]
```

## DESCRIPTION

The Stop-NLogLogging cmdlet stops logging and clears the current logging configuration.

## EXAMPLES

### Example 1: Dispose all targets, and shuts logging down

```powershell
Stop-NLogLogging
```

This example disposes all targets and shuts logging down. It assumes the configuration instance was set to the static `NLog.LogManager.Configuration` property.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Object

This cmdlet does not generate any output.

## NOTES

## RELATED LINKS
