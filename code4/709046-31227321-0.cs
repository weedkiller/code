           Clipboard.SetText(txtClipboard.Text);
       }
       private void btnPaste_Click(object sender, EventArgs e)
       {
           txtResult.Text = Clipboard.GetText();
       }
