    Func<int, Foo> func = x => new Foo(x * 2);
    Expression<Func<int, Foo>> exp = x => new Foo(x * 2);
    var func2 = exp.Compile();
    Array.ForEach(func.Method.GetMethodBody().GetILAsByteArray(), b => Console.WriteLine(b));
    
    var mtype = func2.Method.GetType();
    var fiOwner = mtype.GetField("m_owner", BindingFlags.Instance | BindingFlags.NonPublic);
    var dynMethod = fiOwner.GetValue(func2.Method) as DynamicMethod;
    var ilgen = dynMethod.GetILGenerator();
    
    
    byte[] il = ilgen.GetType().GetMethod("BakeByteArray", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(ilgen, null) as byte[];
    Console.WriteLine("Expression version");
    Array.ForEach(il, b => Console.WriteLine(b));
