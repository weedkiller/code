    public IActionResult Create()
    {
        var vm = new MyViewModel();
        vm.Employees = new List<SelectListItem>
        {
            new SelectListItem {Text = "Shyju", Value = "11"},
            new SelectListItem {Text = "Tom", Value = "12"},
            new SelectListItem {Text = "Jerry", Value = "13"}
        };
        vm.EmployeeIds= new int[] { 12,13} ;  
        return View(vm);
    }
