    public class yourClass
    {
        public double CurrentTotal {get;set;}
    
        protected void yourButtonClickCode()
        {
            // use the proeprty ref here instead of the local
        }
        protected void onExit() 
        {
           System.IO.File.WriteAllText(@"your path.txt", this.CurrentTotal.ToString());
        }    
    }
