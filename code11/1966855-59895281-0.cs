            string File_path = @"C:\Users\yakir\Desktop"; 
            string docfile_path;
            string filename;
            string time = DateTime.Now.ToString("HH.mm.ss");
            string date = DateTime.Today.ToString("dd.MM.yyyy");
            docfile_path = Path.Combine(File_path , "test" , date);
            Directory.CreateDirectory(docfile_path);
            filename = Path.Combine(docfile_path, "worddoc" + "-" + ".docx");
            Application app = new Application();
            Document doc = app.Documents.Add();
            Paragraph oPara1;
            oPara1 = doc.Content.Paragraphs.Add();
            oPara1.Range.Text = "Test Result";
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24;
            oPara1.Range.InsertParagraphAfter();
            oPara1.Range.InsertParagraphAfter();
            Paragraph oPara2;
            oPara2 = doc.Content.Paragraphs.Add();
            oPara2.Range.Text = "Test Name";
            oPara2.Range.Font.Bold = 1;
            oPara2.Format.SpaceAfter = 24;
            oPara2.Range.InsertParagraphAfter();
            doc.SaveAs2(filename);
            doc.Close();
            doc = null;
            app.Quit();
            app = null;
        }
