    var initialQuery = db.tblProperties;
    if(smodel.StatusID != null)
    {
        initialQuery = initialQuery.Where(smodel.StatusID.Contains(p.PropertyLocation));
    }
    var query = initialQuery.ToList();
