    private void btUpload_Click(object sender, EventArgs e)
    {
        bwUpload.RunWorkerAsync(lvFiles);
    }
    
        private void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            ListView lvFiles = (ListView)e.Argument;
        
            for (int i = 0; i < lvFiles.Items.Count; i++)
            {
                if (this.lviFile.InvokeRequired)
    	        {	
    		        
                    Invoke(new MethodInvoker(() =>
                    {
                        ListViewItem lviFile = lviFile.Items[i];
                        ...
                    });
    	        }
                else
                {
                    ListViewItem lviFile = lviFile.Items[i];
                }
            }
        }
