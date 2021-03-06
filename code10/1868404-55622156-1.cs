    public class ClassA
    {
        public int SomeNumber { get; set; }
        public string SomeString { get; set; }
    }
    
    public class ClassB
    {
        public int OtherNumber { get; set; }
        public string OtherString { get; set; }
    }
    
    public static class ExecuteParsingFunction
    {
        public static TDestiny Parse<TOrigin, TDestiny>(TOrigin origin,
                                    Func<TOrigin, TDestiny> parserFunction)
        {
            return parserFunction(origin);
        }
    }
    public static class ParsingFunctions
    {
        public static ClassB ParseAToB(ClassA a)
        {
            return new ClassB { OtherNumber = a.SomeNumber, OtherString = a.SomeString };
        }
        public static IEnumerable<ClassB> ParseManyAToB(IEnumerable<ClassA> aCollection)
        {
            foreach(var a in aCollection)
                yield return ParseAToB(a);
        }
    }
    public void Sample()
    {
        var a = new ClassA { SomeNumber = 1, SomeString = "Test" };
        var manyAs = new List<ClassA> { a };
        var b = ExecuteParsingFunction.Parse(a, ParserFunctions.ParseAToB);
        var manyBs = ExecuteParsingFunction.Parse(manyAs, ParserFunctions.ParseManyAToB);
    }
 
