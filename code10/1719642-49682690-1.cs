    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace PointDrawTest
    {
        public partial class Form1 : Form
        {
            public struct BoundingArea 
            {
                public int x;
                public int y;
                public int width;
                public int height;
            }
    
            public struct Point
            {
                public int x;
                public int y;
            }
    
            int bytesPerPixel;
            byte[] backgroundImageRgbData;
            byte[] imageRgbData;
            private Bitmap displayImage;
            private BoundingArea area;
            private List<Point> points = new List<Point>();
    
            public Form1()
            {
                InitializeComponent();
                LoadPoints();
            }
    
            private void LoadPoints()
            {
                this.points = new List<Point>();
                this.area = new BoundingArea();
                this.area.x = 0;
                this.area.y = 0;
                this.area.width = 1200;
                this.area.height = 800;
    
                displayImage = new Bitmap(this.area.width, this.area.height, PixelFormat.Format24bppRgb);
                            
                //There are three bytes per pixel in format PixelFormat.Format24bppRgb
                bytesPerPixel = 3;
                
                //Rgb byte data for the image
                int rgbDataSize = this.area.width * this.area.height * bytesPerPixel;
                imageRgbData = new byte[rgbDataSize];
    
                GenerateRandomPoints();
                GenerateBackgroundImage();
                UpdateBitmap();
            }
    
            private void GenerateBackgroundImage()
            {
                Bitmap backgroundImage = new Bitmap(this.area.width, this.area.height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(backgroundImage);
    
                int gridSize = 40;
                int rowCount = this.area.height / gridSize;
                int columnCount = this.area.width / gridSize;
    
                //Set background color to white
                g.Clear(System.Drawing.Color.White);
    
                int penWidth = 1;
                Pen linePen = new Pen(System.Drawing.Color.Gray, penWidth);
    
                //Draw horizontal lines
                for (int i = 0; i < rowCount; i++)
                {
                    float y = i * gridSize;
                    g.DrawLine(linePen, this.area.x, y, this.area.x + this.area.width, y);
                }
    
                //Draw vertical lines
                for (int i = 0; i < columnCount; i++)
                {
                    float x = i * gridSize;
                    g.DrawLine(linePen, x, this.area.y, x, this.area.y + this.area.height);
                }
    
                //Get rgb data from drawn background image and save it to array
                var backgroundData = backgroundImage.LockBits(new Rectangle(this.area.x, this.area.y, this.area.width, this.area.height),
                    ImageLockMode.ReadWrite,
                    backgroundImage.PixelFormat);
    
                IntPtr ptrFirstPixel = backgroundData.Scan0;
    
                int rgbDataSize = this.area.width * this.area.height * bytesPerPixel;
                backgroundImageRgbData = new byte[rgbDataSize];
                Marshal.Copy(ptrFirstPixel, backgroundImageRgbData, 0, backgroundImageRgbData.Length);
    
                backgroundImage.UnlockBits(backgroundData);
            }
    
            private void GenerateRandomPoints()
            {
                int pointCount = 100000;
                var r = new Random();
    
                for (int i = 0; i < pointCount; i++)
                {
                    int pointX = r.Next(this.area.x, this.area.x + this.area.width);
                    int pointY = r.Next(this.area.y, this.area.y + this.area.height);
    
                    points.Add(new Point() { x = pointX, y = pointY });
                }
            }
    
            private void UpdateBitmap()
            {
                var bmpData = this.displayImage.LockBits(new Rectangle(this.area.x, this.area.y, this.area.width, this.area.height),
                    ImageLockMode.ReadWrite,
                    this.displayImage.PixelFormat);
    
                IntPtr ptrFirstPixel = bmpData.Scan0;
                
                //Set image array to default background image
                for (int i = 0; i < imageRgbData.Length; i++)
                {
                    imageRgbData[i] = backgroundImageRgbData[i];
                }
    
                Color pixelColor = System.Drawing.Color.LightGreen;
    
                for (int i = 0; i < this.points.Count; i++)
                {
                    Point p = this.points[i];
                    int bitmapRgbIndex = (p.y * this.area.width + p.x) * bytesPerPixel;
    
                    //Apply color at a specific pixel
                    imageRgbData[bitmapRgbIndex] = pixelColor.B;
                    imageRgbData[bitmapRgbIndex + 1] = pixelColor.G;
                    imageRgbData[bitmapRgbIndex + 2] = pixelColor.R;
                }
    
                //Copy your bitmap byte array to the image
                Marshal.Copy(imageRgbData, 0, ptrFirstPixel, imageRgbData.Length);
    
                this.displayImage.UnlockBits(bmpData);
    
                pbDisplay.Image = this.displayImage;
            }
        }
    }
