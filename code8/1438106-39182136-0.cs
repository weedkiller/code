    TextBox txtA = new TextBox();
        TextBox txtB = new TextBox();
        TextBox txtC = new TextBox();
        int total = 0;
        TextBox txtOne = new TextBox();
        string newOne = "";
        string someDefaultValue = "";
        string lastOne = "";
        protected void txtOne_TextChanged(object sender, EventArgs e)
        {
            total = getTotal(new string[] { txtA.Text, txtB.Text, txtC.Text });
            if (total > -1)
            {
                int totalTest = 0;
                if (int.TryParse(txtOne.Text, out totalTest))
                {
                    if (total > totalTest)
                    {
                        txtOne.Text = lastOne.Length > 0 ? lastOne : someDefaultValue;//default value for the first run when there is no last value 
                        lastOne = newOne;//whatever the value of "one" is this time
                    }
                }
                else
                {
                    MessageBox.Show("YOu must only enter numbers");
                }
            }
            
        }
        private int getTotal(string[] inputs)
        {
            int total = 0;
            int subTotal = 0;
            foreach(string input in inputs)
            {
                if(int.TryParse(input,out subTotal)){
                    total += subTotal;
                }else{
                    MessageBox.Show("You must only enter numbers");
                    return -1;
                }
            }
            return total;
        }
