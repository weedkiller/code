    public string sum()
            {
    
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    string test = dataGridView1.Rows[i].Cells[6].Value.ToString();
    
                    if (test == "")
                    {
                        sum += 0;
                    }
                    else
                    {
                        sum += double.Parse(test);
                    }
                }
                return sum.ToString();
            }
