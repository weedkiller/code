    class SocketHandler
    {
        public static readonly SocketHandler _instance = new SocketHandler();
        TcpCLient client;
        NetworkStream ns;
        static SocketHandler() { }
        private SocketHandler() { }
        public static Single Instancia
        {
            get { return _instance; }
        }
        public void Connect(string remoteIp, int port = 4848)
        {
            client = new TcpClient(remoteIp, port);
            ns = client.GetStream();      
        }
        private void Send(string msg)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            ns.Write(buffer, 0, buffer.Length);
            txtMessage.Clear();
        }
    }
