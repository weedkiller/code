    public string connectionString = null;
    accessString();
    
    internal string accessString()
    {
        return string.IsNullOrEmpty(connectionString)? 
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=" + DBFileName + ";" +
            @"Persist Security Info=False" : connectionString;
    }
