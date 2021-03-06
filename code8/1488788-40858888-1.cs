    foreach (Attachment atch in rptOutputResponse.Response.attachments)
    {
        RptAttachmentsBuffer.AddRow();
        RptAttachmentsBuffer.AppId = rptOutputResponse.Response.appId;
        RptAttachmentsBuffer.Type = atch.type;
        RptAttachmentsBuffer.Name = atch.name;
        RptAttachmentsBuffer.ContentType = atch.contentType;
        byte[] newbytes = Convert.FromBase64String(atch.content);
        string json = Encoding.UTF8.GetString(newbytes);
        System.Windows.Forms.MessageBox.Show(json);
        RptAttachmentsBuffer.ReportContent.AddBlobData(newbytes);
    }
