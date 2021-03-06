	enum MyEnum
	{
		Red = 0xF00,
		Orange = 0xFF0,
		Yellow = 0x0F0,
		Green = 0x0FF,
		Blue = 0x00F,
		Purple = 0xF0F
	}
	
    public static IList<Enum> GetFlaggedValues(Enum flag) 
    {
		return Enum
			.GetValues(flag.GetType())
			.Cast<Enum>()
			.Where(e => e.HasFlag(flag))
			.ToList();
	}
	
	public static void Main()
	{
		var list = GetFlaggedValues(MyEnum.Blue);
		foreach (var e in list)
		{
		    Console.WriteLine(e);
		}
	}
