    private void Update<T>(T entity, Func<DbSet<T>, T> locatorMap) where T : class
    {
    	var entry = Context.Entry(entity);
    	if (entry.State == EntityState.Detached)
    	{
    		var set = Context.Set<T>();
    		T attachedEntity = locatorMap(set); 
    
    		if (attachedEntity != null)
    		{
    			var attachedEntry = Context.Entry(attachedEntity);
    			attachedEntry.CurrentValues.SetValues(entity);
    		}
    		else
    		{
    			entry.State = EntityState.Modified; // This should attach entity
    		}
    	}
    }
