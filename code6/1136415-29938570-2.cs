        <asp:TemplateField>
        <ItemTemplate>
         <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("report_file") %>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
2) C# code:-
    protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                System.Net.WebClient req = new System.Net.WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath("~/ReportFolder/" + filePath) + "\"");
                byte[] data = req.DownloadData(Server.MapPath("~/ReportFolder/" + filePath));
                response.BinaryWrite(data);
                response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
