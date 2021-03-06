    public static string SmartJoin(this List<string> items, string lastSeparator)
    {
        string values = "";
        if (items.Count > 1)
        {
        	values = String.Format("{0} {1} {2}",
        	            String.Join(", ", items.Take(items.Count - 1)),
        	            "and",
        	            items.Last());
        }
        else
        {
        	values = items.ToString();
        }
        return values;
    }
