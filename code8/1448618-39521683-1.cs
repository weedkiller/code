    private void PathExist()
    {
        if (Directory.Exists(folderBrowserDialog.SelectedPath + @"\"))
        {//Answer
            lblExist.Visible = false;
            Properties.Settings.Default.FirstTime = false;
            // Create a new instance of the Form2 class
            MainFrm MainForm = new MainFrm();
            MainForm.Show();
            Hide();
        }//Answer
        else
        {
            lblExist.Visible = true;
            lblExist.Text = "Folder doesn't exist";
            lblExist.ForeColor = Color.Red;
        }
    }
