    //Console Application Example #1 ;)
    static void Main()
    {
        Func<int, int> myfunc = Add2;
        Console.WriteLine(myfunc(7)); // this prints 9
        myfunc = MultBy2;
        Console.WriteLine(myfunc(7)); // this prints 14
    }
    static int Add2(int x)
    {
        // this method adds 2 to its input
        return x + 2;
    }
    static int MultBy2(int x)
    {
        // this method  multiplies its input by 2
        return x * 2;
    }
