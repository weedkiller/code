    cnn.Open();
    OleDbTransaction transaction = cnn.BeginTransaction();
    OleDbCommand cmd = cnn.CreateCommand();
    cmd.Transaction = transaction;
    
    cmd.Parameters.Add(new OleDbParameter(":var1", ds.Tables[0].Rows[i]["USERNAME"].ToString()));
    cmd.Parameters.Add(new OleDbParameter(":var2","1"));
    cmd.CommandText = "UPDATE JCOLEMAN.IBI_TEST SET FLAG=:var2 WHERE USERNAME=:var1";
    cmd.ExecuteNonQuery();
    cmd.Parameters.Clear();
    cnn.Close();
    transaction.Commit();
