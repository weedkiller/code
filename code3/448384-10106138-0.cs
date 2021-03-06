    private void AddTag_Click(object sender, EventArgs e)
    {
        string uriAddTagtoGroup = string.Format("http://localhost:8000/Service/AddTagtoGroup/{0}/{1}", textBox6.Text, textBox7.Text);
        PerformPost(uriAddTagtoGroup);
    }
    public void PerformPost(string uri)
    {
        byte[] arr = Encoding.UTF8.GetBytes(uri);
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
        req.Method = "POST";
        req.ContentType = "application/xml";
        req.ContentLength = arr.Length;
        Stream reqStrm = req.GetRequestStream();
        reqStrm.Write(arr, 0, arr.Length);
        reqStrm.Close();
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        MessageBox.Show(resp.StatusDescription);
        reqStrm.Close();
        resp.Close();
    }
