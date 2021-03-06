    public class User : IDisposable
    {
        public int id { get; protected set; }
        public string name { get; protected set; }
        public string pass { get; protected set; }
    
        public User(int UserID)
        {
            id = UserID;
        }
        public User(string Username, string Password)
        {
            name = Username;
            pass = Password;
        }
    
        // Other functions go here...
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                // free managed resources
            }
        // free native resources if there are any.
    }
