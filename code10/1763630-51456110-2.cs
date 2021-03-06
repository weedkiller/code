    using (SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True"))
    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [StockManagement].[dbo].[Product]
       ([ProductID]
       ,[ProductName]
       ,[SalePrice]
       ,[PurchasePrice]
       ,[Status])
    VALUES
       (@pid, @pname, @salePrice, @purPrice, @status)", con))
    {
    	cmd.Parameters.Add("@pid", SqlDbType.Int).Value = int.Parse(pcodetxt.Text);
    	cmd.Parameters.Add("@pname", SqlDbType.VarChar).Value = pnametxt.Text;
    	cmd.Parameters.Add("@salePrice", SqlDbType.Money).Value = decimal.Parse(rtlpricetxt);
    	cmd.Parameters.Add("@purPrice", SqlDbType.Money).Value = decimal.Parse(purpricetxt.Text);
    	cmd.Parameters.Add("@status", SqlDbType.Int).Value = statuscbox.SelectedIndex;
    
    	con.Open();
    	cmd.ExecuteNonQuery();
    	con.Close(); // This is not needed: it is done by the implicit Dispose when exiting the using block
    }
