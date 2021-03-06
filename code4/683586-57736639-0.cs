    using System.Windows.Forms.DataVisualization.Charting;
    ...
    
    private void chart1_PostPaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
    {
        if(sender is ChartArea)
        {
    
            ChartArea area = (ChartArea)sender;
            if(area.Name == "Default")
            {
                // If Connection line is not checked return
                if( !ConnectionLine.Checked )
                    return;
    
                double max;
                double min;
                double xMax;
                double xMin;
    
                // Find Minimum and Maximum values
                FindMaxMin( out max, out min, out xMax, out xMin );
    
                // Get Graphics object from chart
                Graphics graph = e.ChartGraphics.Graphics;
    
                // Convert X and Y values to screen position
                float pixelYMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,max);
                float pixelXMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMax);
                float pixelYMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,min);
                float pixelXMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMin);
    
                PointF point1 = PointF.Empty;
                PointF point2 = PointF.Empty;
    
                // Set Maximum and minimum points
                point1.X = pixelXMax;
                point1.Y = pixelYMax;
                point2.X = pixelXMin;
                point2.Y = pixelYMin;
    
                // Convert relative coordinates to absolute coordinates.
                point1 = e.ChartGraphics.GetAbsolutePoint(point1);
                point2 = e.ChartGraphics.GetAbsolutePoint(point2);
    
                // Draw connection line
                graph.DrawLine(new Pen(Color.Yellow,3), point1,point2);
            }
        }
    }
    
    private void chart1_PrePaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
    {
        if(sender is ChartArea){
    
            ChartArea area = (ChartArea)sender;
            if(area.Name == "Default")
            {
                double max;
                double min;
                double xMax;
                double xMin;
    
                // Find Minimum and Maximum values
                FindMaxMin( out max, out min, out xMax, out xMin );
    
                // Get Graphics object from chart
                Graphics graph = e.ChartGraphics.Graphics;
    
                // Convert X and Y values to screen position
                float pixelYMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,max);
                float pixelXMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMax);
                float pixelYMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,min);
                float pixelXMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMin);
    
                // Specify width of triangle
                float width = 3;
    
                // Set Maximum points
                PointF [] points = new PointF[3];
                points[0].X = pixelXMax - width;
                points[0].Y = pixelYMax - width - 2;
                points[1].X = pixelXMax + width;
                points[1].Y = pixelYMax - width - 2;
                points[2].X = pixelXMax;
                points[2].Y = pixelYMax - 1;
    
                // Convert relative coordinates to absolute coordinates.
                points[0] = e.ChartGraphics.GetAbsolutePoint(points[0]);
                points[1] = e.ChartGraphics.GetAbsolutePoint(points[1]);
                points[2] = e.ChartGraphics.GetAbsolutePoint(points[2]);
    
                // Draw Maximum trangle
                graph.FillPolygon(new SolidBrush(Color.Red), points);
    
                // Set Minimum points
                points = new PointF[3];
                points[0].X = pixelXMin - width;
                points[0].Y = pixelYMin + width + 2;
                points[1].X = pixelXMin + width;
                points[1].Y = pixelYMin + width + 2;
                points[2].X = pixelXMin;
                points[2].Y = pixelYMin + 1;
    
                // Convert relative coordinates to absolute coordinates.
                points[0] = e.ChartGraphics.GetAbsolutePoint(points[0]);
                points[1] = e.ChartGraphics.GetAbsolutePoint(points[1]);
                points[2] = e.ChartGraphics.GetAbsolutePoint(points[2]);
    
                // Draw Minimum triangle
                graph.FillPolygon(new SolidBrush(Color.Blue), points);
            }
        }
    }
