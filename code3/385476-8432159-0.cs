    public static void Main()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
        // Set the Interval to 600 seconds.
        aTimer.Interval=600000;
        aTimer.Enabled=true;
 
        Console.WriteLine("Press \'q\' to quit the sample.");
        while(Console.Read()!='q');
    }
 
    // Specify what you want to happen when the Elapsed event is raised.
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("10 minutes passed!");
    }
