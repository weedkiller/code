    public class ComputeParam : IAction    
    {    
        int _n;    
        int _time;    
        public ComputeParam()    
        {    
        }    
        public ComputeParam(int n)    
        {    
            this._n = n;    
        }  
        public int Time 
        { 
            get { return this._time; }
            set { this._time = value; }
        }
    for(int i=0; i<=t.Count; i++) 
    { 
        ((ComputeParam)t[i]).Time = 6;
    }
