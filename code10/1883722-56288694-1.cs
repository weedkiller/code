    var wdApp=new Word.Application();
    var docments = wdApp.Documents;
    var doc = docments.Open(pathToSourceDoc);
    var doc2 = docments.Add();
    doc.Content.Copy();
    doc2.Content.Paste();
    doc2.SaveAs(pathToCopyDoc);
    doc2.Close();
    doc.Close();
    Marshal.ReleaseComObject(doc2);
    Marshal.ReleaseComObject(doc);
    Marshal.ReleaseComObject(docments);
    wdApp.Quit();
    Marshal.ReleaseComObject(wdApp);
