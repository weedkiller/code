    public static void Display_Grid(DataGrid d, List<string> S1)
    {
        ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Tables.Add(dt);
        DataColumn cl = new DataColumn("Item Number", typeof(string));
        cl.MaxLength = 200;
        dt.Columns.Add(cl);
        int i = 0;
        foreach (string s in S1)
        {
            DataRow rw = dt.NewRow();
            rw["Item Number"] = S1[i];
            i++;
        }
        d.ItemsSource = ds.Tables[0].AsDataView();
    }
