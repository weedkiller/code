		class OverlayShadow : Control
		{
			protected override void OnPaint(PaintEventArgs e)
			{
				if (Parent != null) {
					Bitmap behind = new Bitmap(Parent.Width, Parent.Height);
					foreach (Control c in Parent.Controls)
						if (c.Bounds.IntersectsWith(this.Bounds) & c != this)
							c.DrawToBitmap(behind, c.Bounds);
					e.Graphics.DrawImage(behind, -Left, -Top);
					behind.Dispose();
				}
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), Bounds);
			}
		}
