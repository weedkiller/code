    byte[] Content= File.ReadAllBytes(FilePath); //missing ;
    Response.ContentType = "text/csv";
    Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
    Response.BufferOutput = true;
    Response.OutputStream.Write(Content, 0, Content.Length);
    Response.End();
