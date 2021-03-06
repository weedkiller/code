    static void Main(string[] args)
    {
        var sum = GetData().TryCast<double>.Sum();
    }
    private static IEnumerable<object> GetData()
    {
        yield return 4.478;
        yield return 4f;
        yield return 0xFF;
        yield return false;
        yield return new List<string> { "foo", "bar" };
    }
    // the extension function
    public static IEnumerable<T> TryCast<T>(this IEnumerable<object> values)
    {
        foreach (var v in values)
        {
            T a = default(T);
            try
            {
                a = (T) Convert.ChangeType(v, typeof (T));
            }
            catch (FormatException)
            {
            }
            yield return a;
        }
    }  
