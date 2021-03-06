    static private DataMismatch GetDifferentRecords(DataTable dataTable1, 
                                                    DataTable dataTable2, 
                                                    string keyID)
    {
      if ( dataTable1.Columns.Count != dataTable2.Columns.Count )
        throw new Exception("Tables have not the same columns count.");
      for ( int indexColumn = 0; indexColumn < dataTable1.Columns.Count; indexColumn++ )
      {
        string columnName1 = dataTable1.Columns[indexColumn].ColumnName;
        string columnName2 = dataTable2.Columns[indexColumn].ColumnName;
        if ( columnName1 != columnName2 )
          throw new Exception($"Tables columns name mismatch : {columnName1} <=> {columnName2}");
        var columnType1 = dataTable1.Columns[indexColumn].DataType;
        var columnType2 = dataTable2.Columns[indexColumn].DataType;
        if ( columnType1 != columnType2 )
          throw new Exception($"Tables columns type mismatch : {columnType1.Name} <=> {columnType2.Name}");
      }
      var result = new DataMismatch();
      for ( int indexRow = 0; indexRow < dataTable1.Rows.Count; indexRow++ )
      {
        object columnKeyValue = null;
        for ( int indexColumn = 0; indexColumn < dataTable1.Columns.Count; indexColumn++ )
          if ( dataTable1.Columns[indexColumn].ColumnName == keyID )
            columnKeyValue = dataTable1.Rows[indexRow][indexColumn].ToString();
        if ( columnKeyValue == null)
          throw new Exception($"Key not found : {keyID}");
        for ( int indexColumn = 0; indexColumn < dataTable1.Columns.Count; indexColumn++ )
        {
          string columnName1 = dataTable1.Columns[indexColumn].ColumnName;
          string columnName2 = dataTable2.Columns[indexColumn].ColumnName;
          var value1 = dataTable1.Rows[indexRow][indexColumn];
          var value2 = dataTable2.Rows[indexRow][indexColumn];
          if ( !value1.Equals(value2) )
          {
            var items = new Tuple<object, object>(value1, value2);
            var mismatch = new Dictionary<string, Tuple<object, object>>();
            mismatch.Add(columnName1, items);
            if ( result.ContainsKey(columnKeyValue) )
              result[columnKeyValue].Add(columnName1, items);
            else
              result.Add(columnKeyValue, mismatch);
          }
        }
      }
      return result;
    }
