    if(!IsPostBack)
    {
        string path = obj.ExecuteScalar(sql);   
        imgOrgLogo.ImageUrl = "/OrgImages/" + path;
        imgOrgLogo.DataBind();
    }
