    //first flatten the data so it's easier to manipulate
    var query = from s in shipments
                from i in s.Invoices
                select new
                {
                    s.PortOfOrigin,
                    s.PortOfDestionation,
                    i.InvoicePeriod,
                    i.Amount
                };
                
    //group the data as desired
    var grouping = query.GroupBy(q => new { q.PortOfOrigin, q.PortOfDestionation, q.InvoicePeriod });
    
    //finally sum the amounts
    var results = from g in grouping
                  select new
                  {
                     g.Key.PortOfOrigin,
                     g.Key.PortOfDestionation,
                     g.Key.InvoicePeriod,
                     Amount = g.Select(s => s.Amount).Sum()
                  };
