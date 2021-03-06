    public static bool HasData(int id, Func<AgeLength, object> selector)
    {
        MyDataContext dc = new MyDataContext ();
        return (from s in dc.Str_table 
                where s.sId == id 
                select s.AgeLengths
                    .Where(a => selector(a) != null)
                    .Any())
               .FirstOrDefault();
    }
