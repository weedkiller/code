    public sealed partial class MessageUC : UserControl
    {
        public string MessType { get; set; }
        public MessageUC()
        {
            InitializeComponent();
            Debug.Writeline(MessType); //null
            Loaded += MessageUC_Loaded;
        }
        
        public void MessageUC_Loaded(object sender, EventArgs e)
        {
            Debug.Writeline(MessType); //new
            this.fetchUserData();
        }
    }
    
