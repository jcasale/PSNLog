namespace Tests;

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using MimeKit;

using SmtpServer;
using SmtpServer.Protocol;
using SmtpServer.Storage;

public class TestMessageStore : MessageStore
{
    private readonly ICollection<MimeMessage> _messages;

    public TestMessageStore(ICollection<MimeMessage> messages) => _messages = messages ?? throw new ArgumentNullException(nameof(messages));

    public override async Task<SmtpResponse> SaveAsync(ISessionContext context, IMessageTransaction transaction, ReadOnlySequence<byte> buffer, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();

        var position = buffer.GetPosition(0);
        while (buffer.TryGet(ref position, out var memory))
        {
            var data = memory.ToArray();
            await stream.WriteAsync(data, 0, data.Length, cancellationToken).ConfigureAwait(false);
        }

        stream.Position = 0;

        var message = await MimeMessage.LoadAsync(stream, cancellationToken).ConfigureAwait(false);
        _messages.Add(message);

        return SmtpResponse.Ok;
    }
}