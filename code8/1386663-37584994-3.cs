    class MyExtList<T>
    {
        private List<T> theList = new List<T>();
    
        public void Remove(T obj) 
        {
            theList.Remove(obj)
            // additional stuff
        }
    }
