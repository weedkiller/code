    do // Checks if the chosen name is also the right name
    {
        string test;
        Console.Write("Are you sure " + temp + " is the right name? (y/n)\n");
        test = Console.ReadLine();
        Console.Write("\n");
        if (test.ToLower() == "y")
        {
            nameIsRight = true;
                    
        }
        else if (test.ToLower() == "n")
        {
            Console.Write("What is your name then?\n");
            temp = Console.ReadLine();
            continue;
        }
        else
        {
            Console.WriteLine("Incorrect input!!!");
            continue;
        }                
    } while (nameIsRight == false);
    return temp;
