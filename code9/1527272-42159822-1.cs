    Multipart multipart = new Multipart("mixed");
    multipart.Add(new MimeKit.TextPart("plain")
    {
        Text = RTFToText($"{line}{sr.ReadToEnd()}")
    });
    foreach (MimeEntity attachment in tnefMessage.Attachments)
    {
        multipart.Add(attachment);
    }
    tnefMessage.Body = multipart;
