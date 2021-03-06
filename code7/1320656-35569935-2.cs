    bool invalidInput = true;
    
    while (invalidInput)
    {
        string str = Console.ReadLine(); 
        char option = char.Parse(str);
        switch (option)
        {
            case 'N':
                Console.WriteLine("Creating New App...");
                invalidInput = false;
                break;
            case 'L':
                Console.WriteLine("Loading App...");
                invalidInput = false;
                break;
            case 'O':
                Console.WriteLine("Loading Options...");
                invalidInput = false;
                break;
            case 'Q':
                Console.WriteLine("Exiting Application...");
                System.Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    }
