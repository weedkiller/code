    if (tollResponse == "yes")
    {
        Console.WriteLine("How much do you pay per trip?");
        string tollTax = Console.ReadLine();
        //toll.Success gets set here.
        Match toll = Regex.Match (tollTax, @"[\d .]+");
        if (toll.Success)
        {
            //Not sure why you are doing this since you aren't using it in the given code
            Math.Round(Convert.ToDecimal(tollTax), 2);
            Console.WriteLine("Good lord that's high... well it's your money");
        }
        else
        {
            //This is an infinite loop because toll.Success is never set again.
            do
            {
                Console.WriteLine("Please enter a proper number");
                tollTax = Console.ReadLine();
            } while (toll.Success == false);
        }
    }
