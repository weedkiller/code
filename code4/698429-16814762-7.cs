    public ActionResult Index()
    {
        var model = new PlanViewModel();
        model.Plans = db.Plan_S
            .Select(p => new SelectListItem
            {
                Value = p.Hours,
                Text = p.PlanNames
            })
            .ToList();
            return View(model);
        }
