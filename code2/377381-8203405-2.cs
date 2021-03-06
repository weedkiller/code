    public abstract class Base {}
    public class D1 : Base {}
    public class D2 : Base {}
    public class D3 : Base {}
     
    public class Test
    {
       public static void Main(string[] args)
       {
           Base b1 = new D1();
           Base b2 = new D2();
     
           Method(b1,b2);
           Method(b2,b1); //arguments swapped!
       }
     
       public static void Method(Base b1, Base b2)
       {
            dynamic x = b1;
            dynamic y = b2;
            Method(x,y); //double-dispatch - the magic happens here!
       }
       public static void Method(D1 d1, D2 d2) 
       {
           Console.WriteLine("(D1,D2)");
       }
       public static void Method(D2 d2, D1 d1) //parameters swapped 
       {
           Console.WriteLine("(D2,D1)");
       }
    }
