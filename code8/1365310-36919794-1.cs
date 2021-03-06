    var classesWithProperties = 
        Assembly.GetExecutingAssembly()
    	        .GetTypes()
    			.Where(t => t.GetInterfaces().Contains(typeof(ISomething)) && t.IsClass)
    			.Select(c => new { ClassName = c.FullName, Properties = c.GetProperties().Select(p => p.Name)})
    			.ToList();
