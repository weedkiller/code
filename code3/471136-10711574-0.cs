    public int ComputersOnNetwork()
    {
       List<string> list = new List<string>();
       using (DirectoryEntry root = new DirectoryEntry("WinNT:"))
       {
           foreach (DirectoryEntry computer in computers.Children)
           {
               if ((computer.Name != "Schema"))
               {
                   list.Add(computer.Name);
               }
           }
    
           int c = list.Count;
           return c;
       }
    }
