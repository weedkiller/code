    // give a method to be run when the save button is clicked
    saveButton.Click += saveButton_Click;
    // implementation of the saveButton's above click event
    private void saveButton_Click(object sender, EventArgs e)
    {
        // index of the checkbox column
        int colIndex = dataGridView1.Columns["checkBoxColumn"].Index;
        List<DataGridViewRow> rows = new List<DataGridViewRow>();
        // loop through entire DataGridView and see if checkbox is checked
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            // checked if the cell's value is true
            if (row.Cells[colIndex].Value != null && (bool)row.Cells[colIndex].Value)
                rows.Add(row);
        }
        // do whatever processing here with rows
    }
