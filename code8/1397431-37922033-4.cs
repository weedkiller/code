    public class BananaPanel : Panel {
        protected override Size MeasureOverride(Size availableSize) {
            double totalX, totalY;
            foreach (UIElement element in Children) {
                element.Measure(availableSize);
                totalX += element.DesiredSize.Width;
                totalY += element.DesiredSize.Height;
            }
            return new Size(totalX, totalY);
        }
        protected override Size ArrangeOverride(Size finalSize) {
            if(InternalChildren.Count == 0) return finalSize;
            double maxValue = Math.Abs(InternalChildren.Count, 2);
            double ratioX = finalSize.Width / maxValue;
            double ratioY = finalSize.Height / maxValue;
            for(int i=0; i<InternalChildren.Count; i++) {
                UIElement element = InternalChildren[i];
                Point p = new Point(Math.Pow(i, 2)*ratioX, Math.Pow(i, 2)*ratioY); //using square here, so it won't be banana-like, use an exponential function
                element.Arrange(new Rect(p, element.DesiredSize));
            }
            return finalSize;
        }
    }
