    public List<ServerLogEntry> GetLastestServerLogEntries(int number)
    {
        string logSource = this.GetEventLogSourceName();
        string Query = String.Format("SELECT * FROM Win32_NTLogEvent WHERE Logfile = 'Application' AND SourceName='{0}'", logSource);
    
        List<ServerLogEntry> logs = new List<ServerLogEntry>();
    
        ManagementObjectSearcher mos = new ManagementObjectSearcher(Query);
    
        foreach (ManagementObject mo in mos.Get())
        {
            ServerLogEntry log = new ServerLogEntry();
            log.Category = Convert.ToInt32(mo["Category"]);
            log.CategoryString = SafeString(mo["CategoryString"]);
            log.ComputerName = SafeString(mo["ComputerName"]);
            log.EventCode = Convert.ToInt32(mo["EventCode"]);
            log.EventIdentifier = Convert.ToInt32(mo["EventIdentifier"]);
            log.EventType = Convert.ToInt32(mo["EventType"]);
            log.EventTypeName = this.ConvertLogEventType(log.EventType);
            log.LogFile = SafeString(mo["LogFile"]);
            log.Message = SafeString(mo["Message"]);
            log.RecordNumber = Convert.ToInt32(mo["RecordNumber"]);
            log.SourceName = SafeString(mo["SourceName"]);
            log.TimeGenerated = this.ConvertLogDateTime(SafeString(mo["TimeGenerated"]));
            log.TimeWritten = this.ConvertLogDateTime(SafeString(mo["TimeWritten"]));
            log.Type = SafeString(mo["Type"]);
            log.User = SafeString(mo["User"]);
            logs.Add(log);
        }
        return logs.OrderByDescending(p => p.TimeGenerated).Take(100).ToList();
    }
    private string SafeString(object propertyValue)
    {
        return (propertyValue != null) ? propertyValue.ToString() : "";
    }
    private string ConvertLogEventType(int eventType)
    {
        switch (eventType)
        {
            case 1: return "Error";
            case 2: return "Warning";
            case 3: return "Information";    
            case 4: return "Security Audit Success";
            case 5: return "Security Audit Failure";
            default: return "Unknown";
        }        
    }
