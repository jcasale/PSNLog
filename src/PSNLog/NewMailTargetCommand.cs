namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogMailTarget")]
[OutputType(typeof(NLog.Targets.MailTarget))]
public class NewMailTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to add new lines between log entries.")]
    public bool? AddNewLines { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets BCC email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).")]
    public NLog.Layouts.Layout Bcc { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets mail message body (repeated for each log message send in one mail).")]
    public NLog.Layouts.Layout Body { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets CC email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).")]
    public NLog.Layouts.Layout CC { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies how outgoing email messages will be handled.")]
    public System.Net.Mail.SmtpDeliveryMethod? DeliveryMethod { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether SSL (secure sockets layer) should be used when communicating with SMTP server.")]
    public bool? EnableSsl { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets encoding to be used for sending e-mail.")]
    public System.Text.Encoding Encoding { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the footer.")]
    public NLog.Layouts.Layout Footer { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets sender's email address (e.g. joe@domain.com).")]
    public NLog.Layouts.Layout From { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the header.")]
    public NLog.Layouts.Layout Header { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to send message as HTML instead of plain text.")]
    public bool? Html { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the layout used to format log messages.")]
    public NLog.Layouts.Layout Layout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the array of email headers that are transmitted with this email message.")]
    public NLog.Targets.MethodCallParameter[] MailHeaders { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the folder where applications save mail messages to be processed by the local SMTP server.")]
    public NLog.Layouts.Layout PickupDirectoryLocation { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the priority used for sending mails.")]
    public NLog.Layouts.Layout<System.Net.Mail.MailPriority> Priority { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether NewLine characters in the body should be replaced with tags.")]
    public bool? ReplaceNewlineWithBrTagInHtml { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets SMTP Authentication mode.")]
    public NLog.Targets.SmtpAuthenticationMode? SmtpAuthentication { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the password used to authenticate against SMTP server (used when SmtpAuthentication is set to 'basic').")]
    public NLog.Layouts.Layout SmtpPassword { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the port number that SMTP Server is listening on.")]
    public NLog.Layouts.Layout<int> SmtpPort { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets SMTP Server to be used for sending.")]
    public NLog.Layouts.Layout SmtpServer { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the username used to connect to SMTP server (used when SmtpAuthentication is set to 'basic').")]
    public NLog.Layouts.Layout SmtpUserName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the mail subject.")]
    public NLog.Layouts.Layout Subject { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating the SMTP client timeout.")]
    public NLog.Layouts.Layout<int> Timeout { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets recipients' email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).")]
    public NLog.Layouts.Layout To { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether the default Settings from System.Net.MailSettings should be used.")]
    public bool? UseSystemNetMailSettings { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.MailTarget();

        if (AddNewLines.HasValue)
        {
            instance.AddNewLines = AddNewLines.Value;
        }

        if (Bcc is not null)
        {
            instance.Bcc = Bcc;
        }

        if (Body is not null)
        {
            instance.Body = Body;
        }

        if (CC is not null)
        {
            instance.CC = CC;
        }

        if (DeliveryMethod.HasValue)
        {
            instance.DeliveryMethod = DeliveryMethod.Value;
        }

        if (EnableSsl.HasValue)
        {
            instance.EnableSsl = EnableSsl.Value;
        }

        if (Encoding is not null)
        {
            instance.Encoding = Encoding;
        }

        if (Footer is not null)
        {
            instance.Footer = Footer;
        }

        if (From is not null)
        {
            instance.From = From;
        }

        if (Header is not null)
        {
            instance.Header = Header;
        }

        if (Html.HasValue)
        {
            instance.Html = Html.Value;
        }

        if (Layout is not null)
        {
            instance.Layout = Layout;
        }

        if (MailHeaders is { Length: > 0 })
        {
            foreach (var item in MailHeaders)
            {
                instance.MailHeaders.Add(item);
            }
        }

        if (Name is not null)
        {
            instance.Name = Name;
        }

        if (PickupDirectoryLocation is not null)
        {
            instance.PickupDirectoryLocation = PickupDirectoryLocation;
        }

        if (Priority is not null)
        {
            instance.Priority = Priority;
        }

        if (ReplaceNewlineWithBrTagInHtml.HasValue)
        {
            instance.ReplaceNewlineWithBrTagInHtml = ReplaceNewlineWithBrTagInHtml.Value;
        }

        if (SmtpAuthentication.HasValue)
        {
            instance.SmtpAuthentication = SmtpAuthentication.Value;
        }

        if (SmtpPassword is not null)
        {
            instance.SmtpPassword = SmtpPassword;
        }

        if (SmtpPort is not null)
        {
            instance.SmtpPort = SmtpPort;
        }

        if (SmtpServer is not null)
        {
            instance.SmtpServer = SmtpServer;
        }

        if (SmtpUserName is not null)
        {
            instance.SmtpUserName = SmtpUserName;
        }

        if (Subject is not null)
        {
            instance.Subject = Subject;
        }

        if (Timeout is not null)
        {
            instance.Timeout = Timeout;
        }

        if (To is not null)
        {
            instance.To = To;
        }

        if (UseSystemNetMailSettings.HasValue)
        {
            instance.UseSystemNetMailSettings = UseSystemNetMailSettings.Value;
        }

        WriteObject(instance);
    }
}
