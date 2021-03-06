    public void LoadData() 
    {
        string cmdText = @"SELECT 1 FROM LoginData 
                           WHERE Username = @name AND AND Password = @pass";
        using(SqlConnection cnn = new SqlConnection("Server=.\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;"))
        using(SqlCommand SelectCommand = new SqlCommand(cmdText, cnn))
        {
           SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = TextBox1.Text;
           SelectCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = TextBox2.Text;
           cnn.Open();
           using(myReader = SelectCommand.ExecuteReader())
           {
               // No need to read anything. If your reader has rows then
               // the user and its password exists 
               // (you don't allow two users have the same name right?)
               if(myReader.HasRows)
               {
                 string script = "alert(\"Login successful!\");";
                 ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
               }
               else
               {
                  string script = "alert(\"Login Failed!\");";
                  ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
               }
          }         
       }
    }
