      protected void lbEmailDocument_Click(object sender, CommandEventArgs e)
    
        {
    
            int index = Int32.Parse(e.CommandArgument.ToString());
    
            Session["strDocumentToAttach"] = gvDocuments.Rows[index].Items.FindItemByKey("lblPath").Value;
    
            Session["strSubject"] = "Case Document E-mail (Case # " + lblCaseNumber.Text.Trim() + ")";
    
            Session["strNote"] = "Please find the attached document " + gvDocuments.Rows[index].Items.FindItemByKey("lblFileName").Value;
    
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "myPopUp", "<script language='Javascript'>mywin=window.open('Case_Email.aspx?CaseID=" + lblCaseID.Text + "', '', 'location=0,status=0,resizable=1,scrollbars=1,height=920px, width=1250px');mywin.moveTo(0,0);</script>", false);
    
    
    
            // Response.Redirect("Case_Email.aspx?CaseID=" + lblCaseID.Text);
    
        }
