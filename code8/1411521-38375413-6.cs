    protected void Page_Load(object sender, EventArgs e)
    {
            jpyRATE = 1.4;
            DataTable subjects = new DataTable();
            if (Page.IsPostBack == false)
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT VehicleMake FROM VehicleDB", con);
                    adapter.Fill(subjects);
                    con.Open();
                    DropDownList1.DataSource = subjects;
                    DropDownList1.DataTextField = "VehicleMake";
                    DropDownList1.DataValueField = "VehicleMake";
                    DropDownList1.DataBind();
                    if(!String.IsNullOrEmpty(Session["vehiclemake"] as string)) 
                    {
                     DropDownList1.SelectedIndex =
                     DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(Session["vehiclemake"].ToString()));
                    }
                    con.Close();
                }
     
      }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makename = DropDownList1.SelectedItem.Value;
            keepname = makename;
            Session["vehiclemake"] = keepname;
            Response.Redirect("default.aspx?QSVehicleMake="+makename);
         }
   
