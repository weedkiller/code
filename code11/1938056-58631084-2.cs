    public async Task GenerateAllPDFs()
    {
    	var allOrders = await _context.Orders.ToListAsync();
    	System.Threading.Tasks.Parallel.ForEach(allOrders, order => 
    	{
    		var document = ...  //PDF generated here, takes about 10 seconds
    		order.PDF = document ;
    	});
    	await _context.SaveChangesAsync();
    }
