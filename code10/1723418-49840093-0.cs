    OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\dbms\jollibee.accdb";
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Employee_Details set username = @un, password= @pw, account_Type= @at, Name=@nm,Middle_Name= @mn, Surname= @sn,address= @add, BirthDate= @bd, Mobile_Number= @mn WHERE ID=@id";
 
        cmd.Parameters.Add("@un", OleDbType.VarChar).Value = username.Text;
        cmd.Parameters.Add("@pw", OleDbType.VarChar).Value = password.Text;
        cmd.Parameters.Add("@at", OleDbType.VarChar).Value = accountType.Text;
        cmd.Parameters.Add("@nm", OleDbType.VarChar).Value = name.Text;
        cmd.Parameters.Add("@mn", OleDbType.VarChar).Value = middlename.Text;
        cmd.Parameters.Add("@sn", OleDbType.VarChar).Value = surname.Text;
        cmd.Parameters.Add("@add", OleDbType.VarChar).Value = address.Text;
        cmd.Parameters.Add("@bd", OleDbType.Date).Value = Convert.ToDateTime(birthdate.Value);
        cmd.Parameters.Add("@mn", OleDbType.VarChar).Value = mobilenumber.Text;
        cmd.Parameters.Add("@id", OleDbType.VarChar).Value = id1;
