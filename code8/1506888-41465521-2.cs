    string line;
    System.Data.DataTable csvData = new System.Data.DataTable();
    csvData.Columns.Add("OnlyColumn", typeof(String));
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
        if(line.StartsWith("-"))
            continue;        
        DataRow newRow = csvData.NewRow();
        newRow["OnlyColumn"] = line.Split('|')[1].Trim();
        csvData.Rows.Add(newRow);
    }
    file.Close();
    InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tablenaam);
