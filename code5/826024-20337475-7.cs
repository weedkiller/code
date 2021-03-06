    using( var db = new TestContext() )
    {
        var myClass = new MyClass()
        {
            ID = 0,
            Objects = new List<MyBaseClass>()
            {
                new MyBaseClass()
                {
                    Name = "Object 1"
                },
                new MyBaseClass()
                {
                    Name = "Object 2"
                }
            }
        };
        var myClass2 = new MyClass2( myClass );
        db.Classes.Add( myClass2 );
        db.SaveChanges();
    }
