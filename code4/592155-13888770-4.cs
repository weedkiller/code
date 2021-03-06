    private void btn_Click(object sender, EventArgs e)
    {
        panel1.Controls.Clear(); //to remove all controls
        //to remove all comboboxes
        foreach (Control item in panel1.Controls.OfType<ComboBox>())
        {
            panel1.Controls.Remove(item); 
        }
       //to remove control by Name
        foreach (Control item in panel1.Controls.OfType<Control>())
        {
            if (item.Name == "bloodyControl")
                panel1.Controls.Remove(item); 
        }
        
        //to remove just one control, no Linq
        foreach (Control item in panel1.Controls)
        {
            if (item.Name == "bloodyControl")
            {
                 panel1.Controls.Remove(item);
                 break; //important step
            }
        }
    }
