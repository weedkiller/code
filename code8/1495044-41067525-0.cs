    using(SqlConnection connect = new SqlConnection("Data Source=THEBEAST;Initial Catalog=newregDB;Integrated Security=True;Pooling=False"))
    {
        connect.Open();
        SqlCommand cmd = new SqlCommand("SELECT [firstname], [dob], [ChildID] FROM [children]", connect);
        SqlDataAdapter sda = new SqlDataAdapater(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt; //give your gridview name here
        GridView1.DataBind();//give your gridview name here
    }
