    Dictionary<string, object> dic1 = new Dictionary<string, object>();
    Dictionary<string, object> dic2 = new Dictionary<string, object>();
    dic1.Add("Key1", new { Name = "abc", Number = "123", Address = "def", Loc = "xyz" });
    dic1.Add("Key2", new { Name = "DEF", Number = "123", Address = "def", Loc = "xyz" });
    dic1.Add("Key3", new { Name = "GHI", Number = "123", Address = "def", Loc = "xyz" });
    dic1.Add("Key4", new { Name = "JKL", Number = "123", Address = "def", Loc = "xyz" });
    dic2.Add("Key1",new { Name = "abc",Number=  "123", Address= "def", Loc="xyz"});
    dic2.Add("Key2", new { Name = "DEF", Number = "123", Address = "def", Loc = "xyz" });
    dic2.Add("Key3", new { Name = "GHI", Number = "123", Address = "def", Loc = "xyz" });
    dic2.Add("Key4", new { Name = "JKL", Number = "123", Address = "def", Loc = "xyz" });
    bool result = dic1.SequenceEqual(dic2); //Do not use that
