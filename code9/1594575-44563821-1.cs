        static void Main(string[] args)
        {
            string[] test = { "t1", "t2", "t3" };
            TestArray(1, test, "Hello");
        }
        static void TestArray(params object[] array)
        {
            foreach (var value in array)
            {
                if (value is IEnumerable<object>)
                    foreach (var element in value as IEnumerable<object>)
                        Console.WriteLine(element);
                else
                    Console.WriteLine(value);
            }
            Console.ReadLine();
        }
