    public class A
    {
        public A(string N)
        {
            Name = N;
        }
        public string Name { get; set; }
        public virtual void GetName()
        {
            Console.Write(Name);
        }
    }
    public class B : A
    {
        public B(string N) : base(N)
        {
        }
        public override void GetName()
        {
            base.GetName();
            Console.Write(new string(Name.Reverse().ToArray()));
        }
    }
