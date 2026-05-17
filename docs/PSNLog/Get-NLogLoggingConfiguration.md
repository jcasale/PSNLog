---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: Get-NLogLoggingConfiguration
---

# Get-NLogLoggingConfiguration

## SYNOPSIS

Gets the current logging configuration.

## SYNTAX

### __AllParameterSets

```
Get-NLogLoggingConfiguration [<CommonParameters>]
```

## DESCRIPTION

The Get-NLogLoggingConfiguration cmdlet gets the current configuration.

The cmdlet will throw if a configuration is not found.

## EXAMPLES

### Example 1: Gets the previously set configuration from the static `NLog.LogManager.Configuration` property

```powershell
$configuration = Get-NLogLoggingConfiguration
```

This example gets the previously set configuration from the static `NLog.LogManager.Configuration` property.

## PARAMETERS

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### NLog.Config.LoggingConfiguration

This cmdlet returns the **NLog.Config.LoggingConfiguration** object from the static `NLog.LogManager.Configuration` property.

## NOTES

## RELATED LINKS
