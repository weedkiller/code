    var connectionString = "YourConnectionStringToTheDB";
    var queryString ="YourSQLQueryHere"; // FROM * IN tbl SELECT * etc...
    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
     }
