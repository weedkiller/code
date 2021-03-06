    public partial class Form1 : Form
    {
        InitializeComponent();
        InitBrowser();
    }
    public ChromiumWebBrowser browser;
    public void InitBrowser()
    {
        var settings = new CefSettings();
        settings.RegisterScheme(new CefCustomScheme
        {
            SchemeName = "localfolder",
            DomainName = "cefsharp",
            SchemeHandlerFactory = new FolderSchemeHandlerFactory(
                rootFolder: @"..\..\..\..\CEFSharpExample\webpage",
                hostName: "cefsharp",
                defaultPage: "index.html" // will default to index.html
            )
        });
        Cef.Initialize(settings);
            
        string html = File.ReadAllText(@"..\..\..\webpage\index.html");
        browser = new ChromiumWebBrowser("localfolder://cefsharp/");
        this.Controls.Add(browser);
        browser.Dock = DockStyle.Fill;   
    }
