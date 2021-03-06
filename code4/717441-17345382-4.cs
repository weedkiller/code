    class SomeClassInOuterScope : IDisposable
    {
        private DataEntities _context;
        public SomeClassInOuterScope()
        {
            _context = new DataEntities();
        }
        public void Test()
        {
            var test = new Test(_context);
            test.InsertRecord(new Person());
            ...............
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
    void SomeMethodInOuterOuterScope()
    {
        var someclass = new SomeClassInOuterScope();
        
        try
        {
            someclass.Test();
            ...............
        }
        catch(Exception ex)
        {
            ....
        }
        finally
        {
            someclass.Dispose();
        }
    }
