    var filingViewModel = new FilingViewModel();
                filingViewModel.filing.Service = dr.Field<string>("Service");
                filingViewModel.filing.filing_Description = dr.Field<string>("filing_Description");
                filingViewModel.filing.Date_Post = dr.Field<DateTime>``("Date_Due");
                model.Add(filingViewModel);
