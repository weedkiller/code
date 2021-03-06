    public class Base
    {
        public Base() : this(true) { }
         
        protected Base(bool runInitializer)
        {
            if (runInitializer)
            {
                this.Initialize();
            }
        }
         
        protected void Initialize()
        {
            ...initialize...
        }
    }
    public class Derived : Base
    {
        // explicitly referencing the base constructor keeps
        // the default one from being invoked.
        public Derived() : base(false)
        {
           ...derived code
           this.Initialize();
        }
    }
