    private void textBox1_TextChanged(object sender, EventArgs e)
    {  
        if (!string.IsNullOrEmpty(textBox1.Text))
        {
            button1.Enabled = true;
        }
        else
            button1.Enabled = false;
    }
