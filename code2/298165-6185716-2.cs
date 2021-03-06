    using System;
    using System.Diagnostics;
    
    namespace ReadEventLog
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string logType = "System";
                
                //use this if your are are running the app on the server
                //EventLog ev = new EventLog(logType, System.Environment.MachineName);    
                //use this if you are running the app remotely
                EventLog ev = new EventLog(logType, "[youservername]");
                
                if (ev.Entries.Count <= 0)
                    Console.WriteLine("No Event Logs in the Log :" + logType);
    
                // Loop through the event log records. 
                for (int i = ev.Entries.Count - 1; i >= 0; i--)
                {
                    EventLogEntry CurrentEntry = ev.Entries[i];
 
                    //use DateTime type to compare on CurrentEntry.TimeGenerated
                    DateTime dt = DateTime.Now;
                    TimeSpan ts = dt.Subtract( CurrentEntry.TimeGenerated);
                    int hours = (ts.Days * 24) + ts.Hours;
                    if (CurrentEntry.Source.ToUpper() == "USER32")
                    {
                        Console.WriteLine("Time Generated:" + CurrentEntry.TimeGenerated);
                        Console.WriteLine("Hours ago:" + hours);
                        Console.WriteLine("Event ID : " + CurrentEntry.InstanceId);
                        Console.WriteLine("Entry Type : " + CurrentEntry.EntryType.ToString());
                        Console.WriteLine("Message :  " + CurrentEntry.Message + "\n");
                    }
                }
                ev.Close();
            }
        }
    }
