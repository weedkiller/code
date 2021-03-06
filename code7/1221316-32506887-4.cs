    using (FileStream fs = new FileStream(outCsvFile, FileMode.Append, FileAccess.Write))
    using (StreamWriter file = new StreamWriter(fs))
    {
        file.WriteLine("ProjectID, ProjectTitle,PublishStatus,NumberOfSubjects,ProjectStartDate,ProjectEndDate,URL");
        foreach(proj in pr.GroupBy(p=>p.ProjectID).Select(p=>p.First()))
        {
            var userIDs = db.GetList(proj.ProjectID);                
            file.WriteLine("{0},\"{1}\",{2},{3},{4},{5},{6}",
               proj.ProjectID,
               proj.ProjectTitle,
               proj.PublishStatus,
               userIDs.Length.ToString(NumberFormatInfo.InvariantInfo),
               proj.ProjectStartDate.ToString("d",DateTimeFormatInfo.InvariantInfo),
               proj.ProjectEndDate.ToString("d",DateTimeFormatInfo.InvariantInfo),
               url[i].ToString());
        }
    }
