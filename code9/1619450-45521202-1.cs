	var collection = new List<FileStatus>()
	{
		new FileStatus(){ Id = 1, Filename = "file1", Date = new DateTime(2016,05,12,11,30,00), Status = "fail"},
		new FileStatus(){ Id = 2, Filename = "file1", Date = new DateTime(2016,05,12,11,35,00), Status = "success"},
		new FileStatus(){ Id = 3, Filename = "file2", Date = new DateTime(2016,05,13,12,01,00), Status = "success"},
		new FileStatus(){ Id = 4, Filename = "file2", Date = new DateTime(2016,05,13,12,02,00), Status = "fail"},
		new FileStatus(){ Id = 5, Filename = "file1", Date = new DateTime(2016,05,13,12,30,00), Status = "success"},
		new FileStatus(){ Id = 6, Filename = "file3", Date = new DateTime(2016,05,13,12,31,00), Status = "fail"}
	};
	
	var result = collection.GroupBy(c => new { c.Filename, c.Date.Date }).Select(c => new
	{
		Row = c.Key.Filename,
		Column = c.Key.Date,
		Value = collection.FirstOrDefault(co => co.Id == c.Max(max => max.Id)).Status
	});
