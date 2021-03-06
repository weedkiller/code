        private CheckBox GetCheckboxFromRadioButton(RadioButton radioButton)
        {
            CheckBox result = new CheckBox();
            //copy text
            result.Text = radioButton.Text;
            //copy colors
            result.BackColor = radioButton.BackColor;
            result.ForeColor = radioButton.ForeColor;
            //copy checked state
            result.Checked = radioButton.Checked;
            //copy parent container
            result.Parent = radioButton.Parent;
            //copy size and location
            result.Bounds = radioButton.Bounds;
            // copy other properies you need here
            //...
            return result;
        }
