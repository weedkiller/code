     if (FileUpload1.FileName != "")
     {
    FileInfo fi = new FileInfo(FileUpload1.FileName);
    byte[] documentContent = FileUpload1.FileBytes;
    
    string name = fi.Name;
    string extn = fi.Extension;
    
    // Add Connection string here //
    da.InsertCommand.Parameters.Add("@DocumentName", SqlDbType.VarChar).Value = name;
    da.InsertCommand.Parameters.Add("@DocumentContent", SqlDbType.VarBinary).Value = documentContent;
    da.InsertCommand.Parameters.Add("@DocumentExt", SqlDbType.VarChar).Value = extn;
    
    cs.Open();
    da.InsertCommand.ExecuteNonQuery();
    cs.Close();
    }
    else
    {
    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('No Files Uploaded');", true);
    }
