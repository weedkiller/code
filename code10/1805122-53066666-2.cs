    public class ClassB()
    {
        private readonly ClassA _a;
        public ClassB(ClassA a)
        {
            _a = a;
        }
        public void FetchData(){
            _a.LogMessage("Fetch data starts");
            // Fetching data here...
            _a.LogMessage("Fetch data ends");
        }
    }
