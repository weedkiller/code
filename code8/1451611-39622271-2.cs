    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace ConsoleExRun
    {
        class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
            static void Main(string[] args)
            {
                AllocConsole();
                Process proc = new Process();
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.FileName = "ping";
                proc.StartInfo.Arguments = "localhost";
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.Start();
                Form f = new Form();
                Application.Run(f);
            }
        }
    }
