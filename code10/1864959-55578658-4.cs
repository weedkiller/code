    WebClient wc = new WebClient();
    MemoryStream stream = new MemoryStream(wc.DownloadData("https://www.dropbox.com/s/l3maq8j3yzciedw/App%20in%205%20minutes.PNG?raw=1"));
    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
    stream.Position = 0;
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    bi.StreamSource = stream;
    bi.EndInit();
    image1.Source = bi;
