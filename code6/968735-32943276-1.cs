    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=ZoneWiseReport.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    GridViewZoneReport.AllowPaging = false;
    this.BindGridView();
    GridViewZoneReport.DataBind();
    GridViewZoneReport.RenderControl(hw);
    GridViewZoneReport.HeaderRow.Style.Add("width", "15%");
    GridViewZoneReport.HeaderRow.Style.Add("font-size", "10px");
    GridViewZoneReport.Style.Add("text-decoration", "none");
    GridViewZoneReport.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
    GridViewZoneReport.Style.Add("font-size", "8px");
    StringReader sr = new StringReader(sw.ToString());
    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    pdfDoc.Open();
    htmlparser.Parse(sr);
    pdfDoc.Close();
    Response.Write(pdfDoc);
    Response.End();     
