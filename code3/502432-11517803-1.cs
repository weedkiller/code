    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    ...
    ((System.Web.UI.WebControls.Button)(e.CommandSource)).CommandArgument - is the id of current row
    ...
    }
