    public class WicBitmapSource : System.Windows.Media.Imaging.BitmapSource, IDisposable
    {
        public WicBitmapSource(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            using (var fac = new ImagingFactory())
            {
                using (var dec = new SharpDX.WIC.BitmapDecoder(fac, filePath, DecodeOptions.CacheOnDemand))
                {
                    Frame = dec.GetFrame(0);
                }
            }
        }
        public WicBitmapSource(BitmapFrameDecode frame)
        {
            if (frame == null)
                throw new ArgumentNullException(nameof(frame));
            Frame = frame;
        }
        public BitmapFrameDecode Frame { get; }
        public override int PixelWidth => Frame.Size.Width;
        public override int PixelHeight => Frame.Size.Height;
        public override double Height => PixelHeight;
        public override double Width => PixelWidth;
        public override double DpiX
        {
            get
            {
                Frame.GetResolution(out double dpix, out double dpiy);
                return dpix;
            }
        }
        public override double DpiY
        {
            get
            {
                Frame.GetResolution(out double dpix, out double dpiy);
                return dpiy;
            }
        }
        public override System.Windows.Media.PixelFormat Format
        {
            get
            {
                // this is a hack as PixelFormat is not public...
                var ct = typeof(System.Windows.Media.PixelFormat).GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    new[] { typeof(Guid) },
                    null);
                return (System.Windows.Media.PixelFormat)ct.Invoke(new object[] { Frame.PixelFormat });
            }
        }
        public override BitmapPalette Palette
        {
            get
            {
                using (var fac = new ImagingFactory())
                {
                    var palette = new Palette(fac);
                    try
                    {
                        Frame.CopyPalette(palette);
                    }
                    catch
                    {
                        // no indexed palette
                        return null;
                    }
                    var list = new List<Color>();
                    foreach (var c in palette.GetColors<int>()) // gets RGBA
                    {
                        // little-endian: RGBA-> ABGR
                        var abgr = BitConverter.GetBytes(c);
                        var color = Color.FromArgb(abgr[0], abgr[3], abgr[2], abgr[1]);
                        list.Add(color);
                    }
                    return new BitmapPalette(list);
                }
            }
        }
        public override void CopyPixels(Int32Rect sourceRect, Array pixels, int stride, int offset)
        {
            if (offset != 0)
                throw new NotSupportedException();
            Frame.CopyPixels(
                new SharpDX.Mathematics.Interop.RawRectangle(sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height),
                (byte[])pixels, stride);
        }
        public void Dispose() => Frame.Dispose();
        public override event EventHandler<ExceptionEventArgs> DecodeFailed;
        public override event EventHandler DownloadCompleted;
        public override event EventHandler<ExceptionEventArgs> DownloadFailed;
        public override event EventHandler<DownloadProgressEventArgs> DownloadProgress;
        protected override Freezable CreateInstanceCore() => throw new NotImplementedException();
    }
