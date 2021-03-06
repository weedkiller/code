        private static SerialPort myport;
        static void Main(string[] args)
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            myport = new SerialPort();  //Setting up the Serial Port
            myport.BaudRate = 9600;
            myport.PortName = "COM4";
            myport.Open();
            if (myport.IsOpen)
            {
                myport.WriteLine("You are are now connected to GDC-IoT Number 1");
                myport.WriteLine("ALETS - Actionable Law Enforcment Technology Software");
            }
            while (true)
            {
                string data_rx = myport.ReadLine();     // Read Serial Data
                Console.WriteLine(data_rx);
            }
        }
        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (myport == null)
            {
                Console.WriteLine("port has not yet been assigned");
            }
            else if (!myport.IsOpen)
            {
                Console.WriteLine("port is not open");
            }
            else
            {
                myport.WriteLine("PING");
            }
        }
    }
