    public interface ISomeBindingList<out T>
    {
        T Get();
    }
    public class TrivialExtensionSomeBindingList<T> : SomeBindingList<T>, ISomeBindingList<T>
    {
    }
    public abstract class ParentClass
    {
        public abstract ISomeBindingList<ParentClass> parentList();
    }
    public class ChildClass : ParentClass
    {
        private ISomeBindingList<ChildClass> myList;
        public ChildClass()
        {
            // this could load from/bind to a database
            myList = new TrivialExtensionSomeBindingList<ChildClass>();
        }
        public override ISomeBindingList<ParentClass> parentList()
        {
            return myList;
        }
    }
