    public static void Method(SqlDataReader _read, Action<SqlDataReader> processColumns)
    {
        if (_read.HasRows)
        {
            while (_read.Read())
            {
                ProcessColumns(_read);
            }
        }
    }
