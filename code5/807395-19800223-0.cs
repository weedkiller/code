	private readonly List<string> _strings = new List<string>();
    public IEnumerable<string> MyStrings 
    { 
        get 
        { 
            new ReadOnlyCollection<string>(_strings);
        }
    }
