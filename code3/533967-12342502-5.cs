    protected void btnEnter_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
    	var Counter = Int32.Parse(btn.Text);
    
        // here you save the name in the array
        //  an magically is saved inside the page on viewstates data
        //  and you can have it anywhere on code behind.
        cArrKeepNames[Counter] = NameFromEditor.Text;
    
    	Counter++;
    	if(Counter >= 5)
    	{   
    	    btn.Enable = false;
    		Label1.Text = "No more studen's names please";
    	}
    	else
    	{  
    		btn.Text = Counter.ToString();
    
    		Label1.Text = "Enter Another student's name";
    	}
    }
