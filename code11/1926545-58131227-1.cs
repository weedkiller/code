    public void Color()
    {
        for(int i = 0; i< dataGridView1.Rows.Count; i++)
        {
            if (dataGridView1.Rows[i].Cells[11].Value == null || dataGridView1.Rows[i].Cells[11].Value == DBNull.Value)
            {
                 dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
            }    
            else
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
    }
