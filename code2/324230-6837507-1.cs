    public virtual T Get(int id)
    {
        if(T is IIDInterface)
           return ObjectSet.First(x => ((T)x).Id == id) 
        return default(T);
    }
