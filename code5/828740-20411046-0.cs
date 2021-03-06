    SqlConnection sqlc= new SqlConnection("data source=. ; database=LDatabase; integrated security=true");
    SqlCommand cmd = new SqlCommand("select MAX(G_ID) as MAXID from Groups", sqlc);
    
    sqlc.Open();
    try {
        using (SqlDataReader reader = cmd.ExecuteReader()) {
            int MaxID = 0;
            while (reader.Read()) {
                MaxID = Convert.ToInt32(Reader["MAXID"].ToString());
                MaxID += 1;
            }
        }
    }
    finally {
        sqlc.Close();
    }
