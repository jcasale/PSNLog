namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogDatabaseParameterInfo")]
[OutputType(typeof(NLog.Targets.DatabaseParameterInfo))]
public class NewDatabaseParameterInfoCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets whether empty value should translate into DbNull. Requires database column to allow NULL values.")]
    public bool? AllowDbNull { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the culture used for parsing parameter string-value for type-conversion")]
    public System.Globalization.CultureInfo Culture { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter DbType.")]
    public string DbType { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the fallback value when result value is not available")]
    public NLog.Layouts.Layout DefaultValue { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets convert format of the database parameter value.")]
    public string Format { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout that should be use to calculate the value for the parameter.")]
    public NLog.Layouts.Layout Layout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter name.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the type of the parameter.")]
    public System.Type ParameterType { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter precision.")]
    public byte? Precision { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter scale.")]
    public byte? Scale { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter size.")]
    public int? Size { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.DatabaseParameterInfo();

        if (this.AllowDbNull.HasValue)
        {
            instance.AllowDbNull = this.AllowDbNull.Value;
        }

        if (this.Culture is not null)
        {
            instance.Culture = this.Culture;
        }

        if (this.DbType is not null)
        {
            instance.DbType = this.DbType;
        }

        if (this.DefaultValue is not null)
        {
            instance.DefaultValue = this.DefaultValue;
        }

        if (this.Format is not null)
        {
            instance.Format = this.Format;
        }

        if (this.Layout is not null)
        {
            instance.Layout = this.Layout;
        }

        if (this.Name is not null)
        {
            instance.Name = this.Name;
        }

        if (this.ParameterType is not null)
        {
            instance.ParameterType = this.ParameterType;
        }

        if (this.Precision.HasValue)
        {
            instance.Precision = this.Precision.Value;
        }

        if (this.Scale.HasValue)
        {
            instance.Scale = this.Scale.Value;
        }

        if (this.Size.HasValue)
        {
            instance.Size = this.Size.Value;
        }

        this.WriteObject(instance);
    }
}
