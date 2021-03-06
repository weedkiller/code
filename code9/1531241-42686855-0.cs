    using System;
    
    namespace PSExec_42280413
    {
        class Program
        {
            static void Main(string[] args)
            {
                DoIt();
            }
    
            private static void DoIt()
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.ErrorDataReceived += Proc_ErrorDataReceived;
                proc.OutputDataReceived += Proc_OutputDataReceived;
                proc.Exited += Proc_Exited;
                proc.StartInfo.FileName = @"c:\windows\syswow64\psexec_64.exe";
                proc.StartInfo.Arguments = @"-i -u usr -p pwd \\server -c M:\StackOverflowQuestionsAndAnswers\PSExec_42280413\PSExec_42280413\TheBatFile.bat";
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.EnableRaisingEvents = true;//
                proc.Start();
    
                //if the process runs too quickly, the event don't have time to raise and the application exits.
                //this here takes care of slooowwwwwiiinnnnnggggg things down
                Int64 bigone = 200000000000;
                while (bigone > 0)
                {
                    bigone--;
                }
    
                //though it doesn't matter how long you wait for... only the Exit event gets raised.
    
            }
    
            private static void Proc_Exited(object sender, EventArgs e)
            {            
                string theoutput = ((System.Diagnostics.Process)sender).StandardError.ReadToEnd();
                string theoutput2 = ((System.Diagnostics.Process)sender).StandardOutput.ReadLine();
                System.Diagnostics.Debugger.Break();
            }
    
            private static void Proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                string theoutput = ((System.Diagnostics.Process)sender).StandardError.ReadToEnd();
                string theoutput2 = ((System.Diagnostics.Process)sender).StandardOutput.ReadLine();
                System.Diagnostics.Debugger.Break();
            }
    
            private static void Proc_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                string theoutput = ((System.Diagnostics.Process)sender).StandardError.ReadToEnd();
                string theoutput2 = ((System.Diagnostics.Process)sender).StandardOutput.ReadLine();
                System.Diagnostics.Debugger.Break();
            }
        }
    }
