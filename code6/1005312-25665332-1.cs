    var now = DateTime.Now;
    var newName = String.Format("{0}.{1:0000}{2:00}{3:00}-{4:00}{5:00}{6:00},
        oldName,
        now.Year, now.Month, now.Day,
        now.Hour, now.Minute, now.Second);
    System.IO.File.Move(oldname, newName);
