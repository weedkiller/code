    GraphicsPath path = new GraphicsPath();
    path.AddArc(0, 0, (this.Width / 2), (this.Height / 2), 135, 195);
    path.AddArc((this.Width / 2), 0, (this.Width / 2), (this.Height / 2), 210, 195);
    path.AddLine((this.Width / 2), this.Height, (this.Width / 2), this.Height);
    using (Region r = new Region(path)) {
      e.Graphics.ExcludeClip(r);
    }
    // continue drawing...
    e.Graphics.Clear(Color.Yellow);
    
