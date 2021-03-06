    public class TestController : Controller
    {
        // GET: Test
        public async Task<ActionResult> Index()
        {
            DateTime BeginDate = new DateTime(2015, 1, 1);
            DateTime EndDate = new DateTime(2015, 12, 31);
            string AuthenticatedUser = "123473306";
            bool RecognizedOrSubmitted = true;
            
            string VPath = "api/WebAPI/GetAllRecognitionsBySupervisorAll";
            ViewModels.AllRecognitionsbyAllSupervisors  AllRByAllS = new ViewModels.AllRecognitionsbyAllSupervisors(BeginDate, EndDate, AuthenticatedUser, RecognizedOrSubmitted);
            var baseUrl = new Uri("http://localhost:1234/");//Replace with api host address 
            var client = new HttpClient();//Use this to call web api
            client.BaseAddress = baseUrl;
            //post viewmodel to web api using this extension method
            var response = await client.PostAsJsonAsync(VPath, AllRByAllS);
            return View();
      }
    }
