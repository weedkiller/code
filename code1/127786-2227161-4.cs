        private void YourControl_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.Alt)
            {
                //YourCode
                e.Handled = true;
            }
        }
        private void YourControl_KeyUp(object sender, KeyEventArgs e)
        { 
            if (e.KeyData.ToString() == "Menu")
            {
                //YourCode
                e.Handled = true;
            }
        }
