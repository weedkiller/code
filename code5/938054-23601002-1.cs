    foreach (var columnName in lines.First()
                 .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
    {
        if (columnName == "Gender")
        {
            var dgc = new DataGridViewComboBoxColumn() { Name = "hi", HeaderText = "bye" };
            dgc.Items.AddRange( "Male", "Female" );
            dataGridView1.Columns.Add(dgc);
            continue;
        }
        dataGridView1.Columns.Add(columnName, columnName);
    }
