    foreach (String item in param.Component.Attributes[0].Item)
    {
        radio = new RadioButton()
        {
            Content = item,
            GroupName = "MyRadioButtonGroup",
           // Name = "param_"+param.Name
        };
        radio.Checked += (o, e) =>
        {
            txtblkShowStatus.Text = item;             
        };
        sp.Children.Add(radio);
    
        count++;   
    radio.IsEnabled = false;             
    }
