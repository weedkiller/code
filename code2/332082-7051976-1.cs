        public Form1()
        {
            InitializeComponent();
            pt = this.Location;
        }
        private Point pt;
        private void Form1_Move(object sender, EventArgs e)
        {
            this.Location = pt;
        }
