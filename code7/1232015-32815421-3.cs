    private void SubMenu_Click(object sender, EventArgs e)
    {
        var currentItem = sender as ToolStripMenuItem;
        if (currentItem != null)
        {
            //Here we look at owner of currentItem
            //And get all children of it, if the child is ToolStripMenuItem
            //So we don't get for example a separator
            //Then uncheck all
            ((ToolStripMenuItem)currentItem.OwnerItem).DropDownItems
                .OfType<ToolStripMenuItem>().ToList()
                .ForEach(item =>
                {
                    item.Checked = false;
                });
            //Check the current items
            currentItem.Checked = true;
        }
    }
