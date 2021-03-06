    private Dictionary<int, string> _comboBoxValues = new Dictionary<int, string>();
    private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
    {
        if (e.Column.FieldName != "test")
            return;
        var rowHandle = gridView1.GetRowHandle(e.ListSourceRowIndex);
        int id = (int)gridView1.GetRowCellValue(rowHandle, "id");
        if (e.IsSetData)
            _comboBoxValues[id] = (string)e.Value;
        else if (e.IsGetData && _comboBoxValues.ContainsKey(id))
            e.Value = _comboBoxValues[id];
    }
