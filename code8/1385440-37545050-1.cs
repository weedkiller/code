    private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 0) //Option 1
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();  //<=========problem number2
            ds.ReadXml(@"C:\XMLFile1.xml");  //<<====================== File1
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow Dr in dt.Rows)
                {
                    ListViewItem lv = new ListViewItem(dt.Rows[i]["ID"].ToString());
                    lv.SubItems.Add(dt.Rows[i]["Name"].ToString());
                    lv.SubItems.Add(dt.Rows[i]["group"].ToString());
                    lv.SubItems.Add(dt.Rows[i]["document"].ToString());
                    i++;
                    listView1.Items.Add(lv);
    
    
                }
            }
            if (comboBox1.SelectedIndex == 1)  //Option 2
            {
                DataSet ds1 = new DataSet();
                DataTable dt1 = new DataTable();
                ds1.ReadXml(@"C:\XMLFile1.xml");     //<<====================== still File1
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow qw in dt1.Rows)
                    {
                        ListViewItem lv = new ListViewItem(dt1.Rows[i]["ID"].ToString());
                        lv.SubItems.Add(dt1.Rows[i]["Name"].ToString());
                        lv.SubItems.Add(dt1.Rows[i]["group"].ToString());
                        lv.SubItems.Add(dt1.Rows[i]["document"].ToString());
                        i++;
                        listView1.Items.Add(lv);
    
    
                    }
                }
            }
        }
    }
