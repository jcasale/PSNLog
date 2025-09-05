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
        HelpMessage = "Gets or sets the culture used for parsing parameter string-value for type-conversion.")]
    public System.Globalization.CultureInfo Culture { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter DbType.")]
    public string DbType { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database parameter DbType (without reflection logic).")]
    public System.Data.DbType? DbTypeEnum { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the fallback value when result value is not available.")]
    public NLog.Layouts.Layout DefaultValue { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets convert format of the database parameter value.")]
    public string Format { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout used for rendering the database-parameter value.")]
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

        if (AllowDbNull.HasValue)
        {
            instance.AllowDbNull = AllowDbNull.Value;
        }

        if (Culture is not null)
        {
            instance.Culture = Culture;
        }

        if (DbType is not null)
        {
            instance.DbType = DbType;
        }

        if (DbTypeEnum.HasValue)
        {
            instance.DbTypeEnum = DbTypeEnum.Value;
        }

        if (DefaultValue is not null)
        {
            instance.DefaultValue = DefaultValue;
        }

        if (Format is not null)
        {
            instance.Format = Format;
        }

        if (Layout is not null)
        {
            instance.Layout = Layout;
        }

        if (Name is not null)
        {
            instance.Name = Name;
        }

        if (ParameterType is not null)
        {
            instance.ParameterType = ParameterType;
        }

        if (Precision.HasValue)
        {
            instance.Precision = Precision.Value;
        }

        if (Scale.HasValue)
        {
            instance.Scale = Scale.Value;
        }

        if (Size.HasValue)
        {
            instance.Size = Size.Value;
        }

        WriteObject(instance);
    }
}
