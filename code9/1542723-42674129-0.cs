    private void UnlockVnos(Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c is TextBox)
            {
                var textbox = c as TextBox;
                textbox.ReadOnly = textbox.Tag == "myTag";
                textbox.BackColor = Color.FromArgb(255, 255, 192);
            }
        }
    }
