    public class ServiceClass
    {
        public ActionClass Printer {set; get;}
        public void RegisterEvent()
        {
            Printer.PrintPage += ActionClass_PrintPage;
        }
    }
    public class ActionClass
    {
        event PrintPageEventHandler PrintPage;
        public void ActionClass_PrintPage( object sender, PrintPageEventArgs e )
        {
            // Action here.
        }
    }
    [Test]
    public void RegisterEvent_Test()
    {
        var service = new ServiceClass();
        
        var mockActionClass = MockRepository.GenerateMock<IActionClass>();
        service.Printer = mockActionClass;
        service.RegisterEvent();
        //mockActionClass.AssertWasCalled(x => x.PrintPage += Arg<PrintPageEventHandler>.Is.Anything); // Do not work.
        //mockActionClass.AssertWasCalled(x => x.PrintPage += Arg<EventHandler<PrintPageEventArgs>>.Is.Anything); // Can not compile.
        mockActionClass.AssertWasCalled(x => x.PrintPage += x.ActionClass_PrintPage); // This works.
    }
