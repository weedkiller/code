    var users = _usersRepository.Users.ToList().Select(u => new SelectListItem
                                        {
                                            Text = u.FirstName + " " + u.LastName,
                                            Value = u.UserID.ToString()
                                        }
    
    return View(new MyViewModel { Users = users });
