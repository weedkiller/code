    DateTime zeroTime = new DateTime(1, 1, 1);
    DateTime a = new DateTime(2007, 1, 1);
    DateTime b = new DateTime(2007, 1, 1);
    TimeSpan span = b - a;
    int years = (zeroTime + span).Year - 1; // because we start at year 1 for the Gregorian calendar, we must subtract a year here.
    Console.WriteLine("Yrs elapsed: " + years); // 1, where my other algorithm resulted in 0.
