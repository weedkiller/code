    using (FileStream stream = new FileStream(this.ImageFileName, FileMode.Open, FileAccess.Read))
                        {
                            using (Image tif = Image.FromStream(stream, false, false))
                            {
                                float width = tif.PhysicalDimension.Width;
                                float height = tif.PhysicalDimension.Height;
                                float hresolution = tif.HorizontalResolution;
                                float vresolution = tif.VerticalResolution;
                             }
                        }
