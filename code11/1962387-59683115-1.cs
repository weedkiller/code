    static void DisplayPeople(string title, List<Person> people, PersonFilter filter)
    {
        Console.WriteLine(title);
        foreach (var item in people)
        {
            if ( filter.Pass(item) ) Console.WriteLine($"{item.FirstName}, ${item.Age} years old");
        }
    }
    // and then ...
    DisplayPeople("children", people, new ChildFilter());
        
