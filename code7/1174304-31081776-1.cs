     var bytes = value as byte[]; 
     using(var stream = new MemoryStream(bytes, 0, bytes.Length))
     {
        //set this to the beginning of the stream
        stream.Position = 0;
        var bitmapImage = new BitmapImage();
        bitmapImage.SetSource(stream);
     }
