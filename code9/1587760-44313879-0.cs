        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                selectedText = richTextBox1.SelectedText;
                Point relativePoint = this.PointToClient(Cursor.Position); //Mouse Position e.g. most likely positon of your selected text
                panel1.Location = relativePoint; //set your panel pos
                panel1.BringToFront(); //Bring the panel to the top.
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }
