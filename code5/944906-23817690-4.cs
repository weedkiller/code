    public class ImageScaleInfo {
        //The page's unit space, almost always 72
        public Single PageUnits { get; set; }
        //The image's actual dimensions
        public System.Drawing.SizeF ImgSize { get; set; }
        //How the image is placed into the page
        public System.Drawing.SizeF CtmSize { get; set; }
        //Automatically calculate how the image is scaled
        public Single ImgWidthScale { get { return ImgSize.Width / CtmSize.Width; } }
        public Single ImgHeightScale { get { return ImgSize.Height / CtmSize.Height; } }
        //Helper constructor
        public ImageScaleInfo(Single imgWidth, Single imgHeight, Single ctmWidth, Single ctmHeight, Single pageUnits) {
            this.ImgSize = new System.Drawing.SizeF(imgWidth, imgHeight);
            this.CtmSize = new System.Drawing.SizeF(ctmWidth, ctmHeight);
            this.PageUnits = pageUnits;
        }
    }
