    var tcpclnt = new TcpClient();
    Console.WriteLine("Connecting.....");
    
    tcpclnt.Connect(IPAddress);
    // use the ipaddress as in the server program
    
    Console.WriteLine("Connected");
    Console.Write("Enter the string to be transmitted : ");
    
    String str = Console.ReadLine();
    Stream stm = tcpclnt.GetStream();
    
    ASCIIEncoding asen = new ASCIIEncoding();
    byte[] ba = asen.GetBytes(str);
    Console.WriteLine("Transmitting.....");
    
    stm.Write(ba, 0, ba.Length);
    
    byte[] bb = new byte[100];
    int k = stm.Read(bb, 0, 100);
    
    for (int i = 0; i < k; i++)
       Console.Write(Convert.ToChar(bb[i]));
    
    tcpclnt.Close();
