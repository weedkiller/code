            listBox1.Items.Clear();
            foreach (string str in items)
            {
                if (str.ToUpper().Contains(textBox1.Text.ToUpper()))
                {
                    listBox1.Items.Add(str);
                }
            }
        }
