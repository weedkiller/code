    public static void Main()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();
            throw new Exception("test");
            Console.ReadLine();
            process.CloseMainWindow();
            process.Close();
    }
