     BitMap image = new BitMap(path);
     
     // Do some processing
     for(int x = 0; x < image.Width; x++)
     {
         for(int y = 0; y < image.Height; y++)
         {
             Color pixelColor = image.GetPixel(x, y);
             Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
             image.SetPixel(x, y, newColor);
         }
     }
    // Save it again with a different name
    image.Save(newPath);
