     [Authorize(Users="aaron")]
    public class personController : Controller 
    {
        private dumb_so_dumbEntities db = new dumb_so_dumbEntities();
    // GET: /person/
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "FirstName")
            {
                return View((db.Persons.Where(x => x.FirstName.Contains(search)) || (search == null)).ToList());
            }
            else
            {
                return View((db.Persons.Where(x => x.LastName.Contains(search)) || (search == null)).ToList());
            }
        }
    }
