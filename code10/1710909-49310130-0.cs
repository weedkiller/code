        //Subscribe
    [ChildActionOnly]
    [HttpPost]
    public IActionResult Subscribe(SubscribeViewModel vm)
    {
        if (ModelState.IsValid)
        {
            _mailService.SubscribeEmail(vm.Email);
    
            return PartialView(vm);
        }
    
        return PartialView(vm)
    }
