	yourContentControl.ApplyTemplate();
	var canvas = VisualTreeHelper.GetChild(yourContentControl, 0) as Canvas;
	var ellipse = new Ellipse();
	ellipse.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
	ellipse.VerticalAlignment = System.Windows.VerticalAlignment.Top;
	ellipse.Width = 50;
	ellipse.Height = 50;
	ellipse.Margin = new Thickness(0, 0, 0, 50);
	ellipse.Stroke = Brushes.Blue;
	ellipse.StrokeThickness = 1.5;
	ellipse.Fill = Brushes.Yellow;
	canvas.Children.Add(ellipse);
