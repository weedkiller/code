    string s4 = File.ReadAllText(@"a.txt"); 
       string s2 = File.ReadAllText(@"b.txt"); 
     string sn = string.Concat(s4, s2);
    File.WriteAllText(@"join.txt", sn);
    var contents = File.ReadAllLines("join.txt");
        Array.Sort(contents);
        File.WriteAllLines("join.txt", contents);
    string strFile4x = File.ReadAllText(@"join.txt");
    strFile4x = Regex.Replace(    strFile4x,     @"\n(.*?)\r\n\1\r", "");
    File.WriteAllText(@"removeequal.txt", strFile4x);
    var contents = File.ReadAllLines("removeequal.txt");
        Array.Sort(contents);
        File.WriteAllLines("removeequal.txt", contents);
