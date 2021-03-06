    private void AdjustMyCheckBoxProperties()
     {
        // Change the ThreeState and CheckAlign properties on every other click. 
        if (!checkBox1.ThreeState)
        {
           checkBox1.ThreeState = true;
           checkBox1.CheckAlign = ContentAlignment.MiddleRight;
        }
        else
        {
           checkBox1.ThreeState = false;
           checkBox1.CheckAlign = ContentAlignment.MiddleLeft;
        }
    
        // Concatenate the property values together on three lines.
        label1.Text = "ThreeState: " + checkBox1.ThreeState.ToString() + "\n" +
                      "Checked: " + checkBox1.Checked.ToString() + "\n" +
                      "CheckState: " + checkBox1.CheckState.ToString(); 
     }
