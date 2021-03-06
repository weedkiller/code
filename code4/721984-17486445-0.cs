    string contents = "hi";
            string fileName = "aaa.pdf";
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.AddStyleAttribute("font-size", "11px");
            string path = Server.MapPath("~/Images/a.png");
            contents = contents.Replace("~/Images/a.png", path);
            sw.Close();
            hw.Close();
            StringReader sr = new StringReader(contents);
            System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath("~/") + DateTime.Now.Ticks, FileMode.Create);
            Document pdfDoc = new Document(PageSize.A4, 30, 5, 35, 5);
            Document cpdfDoc = new Document(PageSize.A4, 30, 5, 35, 5);
            pdfDoc.PageCount = 2;
            cpdfDoc.PageCount = 2;
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, fs);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            fs.Close();
            HTMLWorker htmlparser2 = new HTMLWorker(cpdfDoc);
            PdfWriter.GetInstance(cpdfDoc, Response.OutputStream);
            cpdfDoc.Open();
            htmlparser2.Parse(sr);
