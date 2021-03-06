    public interface IBox
    {
        Circle Width(string width)
    }
    public interface ICircle
    {
       Circle Radius(string radius)
    }
    public class Circle : ICircle
    {
        private string _radius { get; set; }
    
        public Circle Radius(string radius)
        {
            _radius = radius;
            return this;
        }
    }
    
    public class Box : IBox
    {
        private string _width { get; set; }
    
        public Circle Width(string width)
        {
            _width = width;
            return this;
        }
    }
    public class CircleAndBox : ICircle, IBox // Can't do in c#
    {
        // should contain methods from both Circle and Box, but return CircleAndBox
    }
