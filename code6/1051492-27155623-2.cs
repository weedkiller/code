    private static void Main(string[] args)
    {
        Console.WriteLine(MyFunction(5127));
        Console.WriteLine(MyFunction(1));
        Console.WriteLine(MyFunction(51283271));
        Console.WriteLine(MyFunction(-512));
        Console.WriteLine(MyFunction(0));
    }
        public static double MyFunction(double myNumber)
        {
            return Math.Floor(myNumber) / Math.Pow(10, Math.Abs(myNumber).ToString().Length);
        }
