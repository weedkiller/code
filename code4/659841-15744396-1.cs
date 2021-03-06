    public class Rectangle : IEquatable<Rectangle>
    {
        public string width;
        public string height;
    
        public Rectangle(string s1, string s2)
        {
            this.width = s1; this.height = s2;
        }
    
        `IEquatable.Equals
        public bool Equals(Rectangle obj2)
        {
            if (obj2 == null)
            {
                return false;
            }
            return ((this.width.Equals(obj2.width)) && (this.height.Equals(obj2.height)));
    
        }
       
        `override of object.Equals
        public override bool Equals(Object(o2)
        {
           if(typeof(o2) == typeof(Rectangle))
               return ((Rectangle)this.Equals((Rectangle)o2);
          
           return false;
        } 
       
        'override of object.GetHashCode
        public override int GetHashCode()
        {
            return ((this.width.GetHashCode()) ^ (thisw.height.GetHashCode()));
        }
    }
