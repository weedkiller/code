    public class MyClass
    {
        public delegate object MyDelegate(object value);
    
        public MyDelegate GetMethodByName(string methodName)
        {
            return (MyDelegate)Delegate.CreateDelegate(typeof(MyDelegate), this.GetType().GetMethod(methodName));
        }
    
        public object Method1(object value)
        {
            throw new NotImplementedException();
        }
    
        public object Method2(object value)
        {
            throw new NotImplementedException();
        }
    
        public object Method3(object value)
        {
            throw new NotImplementedException();
        }
    }
