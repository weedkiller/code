    public DataTable GetTable(List list1, List list2)
    {
	 DataTable table = new DataTable();
	 table.Columns.Add("SomeName1", typeof(int));
	 table.Columns.Add("SomeName2", typeof(string));
	 var collection = list1.Join(list2, x => x, y => y, (x, y) => new { X = x, Y = y });
     foreach ( var row in collection) 
	   {
	    table.Rows.Add(row.x, row.y);
	   }
	 return table;
      }
