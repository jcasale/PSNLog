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

The Add-NLogLoggingConfiguration cmdlet adds the specified configuration instance to the static NLog.LogManager.Configuration property.

The cmdlet will throw if an existing configuration is already set. Use the Stop-NLogLogging cmdlet to shut down logging before setting a new configuration.