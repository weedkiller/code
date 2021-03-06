    private static void Main()
    {
        var src = @"<Test>
        <Foo.Alpha>value 1</Foo.Alpha>
        <Foo.Beta>value 2</Foo.Beta>
        </Test>";
        using (var sreader = new StringReader(src))
        using (var reader = XmlReader.Create(sreader))
        {
            var serializer = new XmlSerializer(typeof(Test));
            var test = (Test)serializer.Deserialize(reader);
            Console.WriteLine(test.Alpha);
            Console.WriteLine(test.Beta);
        }
    }
