namespace PSNLog;

using System;
using System.Management.Automation;

using NLog;
using NLog.Config;
using NLog.Targets;

[Cmdlet(VerbsCommon.New, "NLogLoggingRule")]
[OutputType(typeof(LoggingRule))]
public class NewLoggingRuleCommand : PSCmdlet
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "default",
        HelpMessage = "Specifies the target to be written to when the rule matches.")]
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MinLevel),
        HelpMessage = "Specifies the target to be written to when the rule matches.")]
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MaxLevel),
        HelpMessage = "Specifies the target to be written to when the rule matches.")]
    [ValidateNotNull]
    public Target Target { get; set; }

    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "default",
        HelpMessage = "Specifies the logger name pattern.")]
    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MinLevel),
        HelpMessage = "Specifies the logger name pattern.")]
    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MaxLevel),
        HelpMessage = "Specifies the logger name pattern.")]
    [ValidateNotNullOrEmpty]
    public string LoggerNamePattern { get; set; }

    [Parameter(
        Position = 2,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MinLevel),
        HelpMessage = "Specifies the minimum log level needed to trigger this rule.")]
    [Parameter(
        Position = 2,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MaxLevel),
        HelpMessage = "Specifies the minimum log level needed to trigger this rule.")]
    [ValidateNotNull]
    public LogLevel MinLevel { get; set; }

    [Parameter(
        Position = 3,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MaxLevel),
        HelpMessage = "Specifies the maximum log level needed to trigger this rule.")]
    [ValidateNotNull]
    public LogLevel MaxLevel { get; set; }

    [Parameter(
        Position = 4,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "default",
        HelpMessage = "Specifies the name of the rule.")]
    [Parameter(
        Position = 4,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MinLevel),
        HelpMessage = "Specifies the name of the rule.")]
    [Parameter(
        Position = 4,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = nameof(MaxLevel),
        HelpMessage = "Specifies the name of the rule.")]
    [ValidateNotNull]
    public string Name { get; set; }

    [Parameter(
        Position = 5,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies whether to quit processing further rules when this one matches.")]
    public SwitchParameter Final { get; set; }

    protected override void ProcessRecord()
    {
        var rule = ParameterSetName switch
        {
            "default" => new LoggingRule(LoggerNamePattern, Target),
            nameof(MinLevel) => new LoggingRule(LoggerNamePattern, MinLevel, Target),
            nameof(MaxLevel) => new LoggingRule(LoggerNamePattern, MinLevel, MaxLevel, Target),
            _ => throw new InvalidOperationException("Unknown parameter set.")
        };

        rule.RuleName = Name;
        rule.Final = Final.IsPresent;

        WriteObject(rule);
    }
}