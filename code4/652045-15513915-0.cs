    using (var fullImg = new Bitmap(workGif))
    {
        var bandImg = fullImg.Clone(new System.Drawing.Rectangle(0, 0, 375, 375), fullImg.PixelFormat);
    	int i = 0;
    	while(Process(bandImg) != null)
    	{
    		if (i == 1)
    			fullImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
    		else if (i == 2)
    			fullImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
    		else if (i== 3)
    			fullImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
    		bandImg = fullImg.Clone(new System.Drawing.Rectangle(0, 0, result.Width, result.Height), fullImg.PixelFormat);
    		i++;
    	}
        bandImg.Save(@"C:\NewImageTest.png");
        string QRinfo = Process(bandImg);
        MessageBox.Show(QRinfo);
    }
