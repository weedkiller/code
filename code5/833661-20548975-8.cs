    SqlDataAdapter daMain = new SqlDataAdapter("SELECT * FROM MAINCATE", conn);
    ds1 = new DataSet();
    daMain.Fill(ds1, "Maincate");
   
    DataTable dt = ds1.Tables["MAINCATE"];
    foreach (DataRow dr in dt.Rows)
    {
       List<string> SubCats = new List<string> {
         dr["Subcat1"].ToString(), 
         dr["Subcat2"].ToString(),
         dr["Subcat3"].ToString(),
         dr["Subcat4"].ToString()
       };
     allRecords.Add(dr["mainCate"].ToString(),SubCats);
     mainCatU.Items.Add(dr["mainCate"].ToString());
    }
   
    mainCatU.DropDownStyle = ComboBoxStyle.DropDownList;
    mainCatU.Enabled = true;
