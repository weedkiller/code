    var set = new HashSet<List<Student>>(new CustomComparer());
    foreach (List<List<Student>> list in source)
    {
      if (set.Contains(list))
        continue;
      set.Add(list)
    }
    
    
    public class CustomComparer : IEqualityComparer<List<Student>>
    {
       public bool EqualsList<Student> one, List<Student> two)
       {
         // code to compare two lists
       }
    
       public int GetHashCodeList<Student> item)
       {
         // code to calculate hash of list<>
       }
    }
