        System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("RegistrationConnectionString");
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        //you dont need to repeat table name in insert command's columns
        cmd.CommandText = "INSERT INTO ReviewText (CinemaID, ReviewText) VALUES (1, 'NorthWestern')";
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
        Response.Write("Your Review was saved");
    }
    catch (Exception ex)
    {
        Response.Write("Error" + ex.ToString());
    }
