    protected void BtnCreate(object sender, EventArgs e)
        {
          SqlConnection connection = new SqlConnection(connectionString);
          //command
          string command = "INSERT INTO [Person] ([personName]) VALUES (@name)";
    
          SqlCommand cmd = new SqlCommand(command, connection);
          cmd.Parameters.AddWithValue("@name", name.Text);
          connection.Open();
          cmd.ExecuteNonQuery();
          connection.Close();
        }
