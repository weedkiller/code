    class A<T>
    {
        public class Item
        {
            //Implementation 
        }
        class B : IInterface<T>
        {
            public Item Get()
            {
                throw new NotImplementedException();
            }
        }
    }
    internal interface IInterface<T>
    {
        A<T>.Item Get();
    }
