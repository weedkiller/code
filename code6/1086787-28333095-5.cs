	private void Form1_Load(object sender, System.EventArgs e)
	{
		DevLog.LogLineAdded += DevLog_LogLineAdded;
	}
	
	private void DevLog_LogLineAdded(object sender, string logLine)
	{
		this.devLogRichTextBox.Text += logLine;
	}
	
	private void Form1_FormClosed(object sender, System.EventArgs e)
	{
		DevLog.LogLineAdded -= DevLog_LogLineAdded;
	}
