    private void listView1_MouseClick(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            } 
        }
    
    you can put connected client information in the contextMenuStrip1. and when you right click on a item, you can show the information from that contextMenuStrip1.
    
    Thanks.
