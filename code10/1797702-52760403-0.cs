    var now = new TimeSpan(DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second).Ticks;
    ...
    ...
    var docs = db.GetCollection<DocDataModel>("docs")
                 .AsQueryable()
                 .Where(e => e.StartTime.Ticks > now)
