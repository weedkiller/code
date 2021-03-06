    public interface IWorker
    {
        ICollection<T> DoWork<T>(IEnumerable<T> values);
    }
        
    public class ListCreationWorker : IWorker
    {
        public ICollection<T> DoWork<T>(IEnumerable<T> values)
        {
            return Factory.CreateList<T>(values);
        }
    }
        
    public class SetCreationWorker : IWorker
    {
        public ICollection<T> DoWork<T>(IEnumerable<T> values)
        {
            return Factory.CreateSet<T>(values);  
        }
    }
       
    public static class Program {
        public static void Main(string[] args) {
            string[] values1 = new string[] { "a", "b", "c" };
            int[] values2 = new int[] { 1, 2, 2, 2 };
    
            IWorker listWorker = new ListCreationWorker();
            IWorker setWorker = new SetCreationWorker();
    
            ICollection<string> result1 = listWorker.DoWork(values1);
            ICollection<int> result2 = listWorker.DoWork(values2); //.Count == 4
            ICollection<int> result3 = setWorker.DoWork(values2); //.Count == 2
        }
    }
    public static class Factory
    {
        public static ICollection<T> CreateSet<T>(IEnumerable<T> values)
        {
            return new HashSet<T>(values);
        }
        public static ICollection<T> CreateList<T>(IEnumerable<T> values)
        {
            return new List<T>(values);
        }
    }
