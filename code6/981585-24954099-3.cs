    using (var con = new SqlConnection("connectionstring")) 
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
       con.Open();
       cmd.Paramers.AddWithValue("@DateColumn", DateTime.Now); // for example
       cmd.ExecuteScalar();
    }
