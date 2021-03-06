    // Create the second, calculated, column.
    DataColumn taxColumn = new DataColumn();
    taxColumn.DataType = System.Type.GetType("System.Decimal");
    taxColumn.ColumnName = "tax";
    taxColumn.Expression = "price * 0.0862";
    // Create third column.
    DataColumn totalColumn = new DataColumn();
    totalColumn.DataType = System.Type.GetType("System.Decimal");
    totalColumn.ColumnName = "total";
    totalColumn.Expression = "price + tax";
    // Add columns to DataTable.
    table.Columns.Add(priceColumn);
    table.Columns.Add(taxColumn);
    table.Columns.Add(totalColumn);
    DataRow row = table.NewRow();
    table.Rows.Add(row);
    DataView view = new DataView(table);
    dataGrid1.DataSource = view;
}
