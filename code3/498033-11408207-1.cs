    DataObject data = (DataObject)Clipboard.GetDataObject();
    DataTable dt = (DataTable)data.GetData(DataFormats.Serializable);
    foreach (DataRow dr in dt.Rows)
    {
        dtData.ImportRow(dr);
    }
    dtData.AcceptChanges();
    grdProgramData.DataSource = dtSessionProgram;
    MessageBox.Show("Data Pasted.");
