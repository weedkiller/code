    private ConcurrentQueue<WorkItem> WorkItems  = new ConcurrentQueue<WorkItem>();
    private CancellationTokenSource WorkTokenSource = new CancellationTokenSource();
    private AutoResetEvent ResetEvent = new AutoResetEvent(true);
    
    void Main()
    {
    	
        StartProcessingWork();
    	for (var x = 0;x<100000;x++)
    	{
    		QueueWorkItem(new WorkItem(){Id= x,SomeData=String.Format("Item : {0}",x)});
    	}
    	
    	Timer cancel = new Timer((a)=>{
    		WorkTokenSource.Cancel();
            ResetEvent.Set();
    	});
    	cancel.Change(5000,0);
    }
    
    public void StartProcessingWork()
    {
    	Task.Factory.StartNew((o)=>
    	{
    		while(!WorkTokenSource.IsCancellationRequested)
    		{
    			WorkItem item = null;
    			if (WorkItems.TryDequeue(out item))
    			{
    				Console.WriteLine("Processing...");
    				ProcessWorkItem(item);
    			}
    			else
    			{
    				Console.WriteLine("Waiting...");
    				ResetEvent.WaitOne();
    			}
    		}
    	},WorkTokenSource.Token,TaskCreationOptions.LongRunning);
    }
    
    
    
    private void ProcessWorkItem(WorkItem item)
    {
    	//Do some work here...
    	for (var x=0;x<100000;x++)
    	{
    		item.Id = x; //blah blah blah
    	}
    	
    	//Use dispatcher to display
    	Dispatcher.CurrentDispatcher.BeginInvoke(()=>DisplayWorkItem(item));
    }
    
    private void DisplayWorkItem(WorkItem item)
    {
    	//DO your display logic here...
    }
    
    public void QueueWorkItem(WorkItem item)
    {
    	WorkItems.Enqueue(item);
    	ResetEvent.Set();
    }
    
    
