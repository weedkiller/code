    public Dictionary<object, object> GetDetails(Type Class)
    {
        //Null check
        if (null == Class)
        {
            throw new ArgumentNullException("Class");
        }
        MvcDemoDBEntities db = new MvcDemoDBEntities();
        //Get the generic dictionary type:
        Type DictType = typeof(Dictionary<,>).MakeGenericType(Class, typeof(object));
        //Create the dictionary object:
        object dict = Activator.CreateInstance(typeof(DictType));
        //Get the Add method:
        var add = DictType.GetMethod("Add", new Type[]{Class, typeof(object)});
        var data = (from h in db.People
                select h).ToList();
        foreach (var item in data)
        {
            //add to the dictionary:
            add.Invoke(dict, new object[]{item, true});
        }
        return dict;
    }
