    EEPROMSlotViewModel checkedVM;    
    string label = string.Empty;
    foreach (EEPROMSlotViewModel vm in SlotChildren)
    {
        if (vm.IsChecked)
        {
            checkedVM = vm;
            break;
        }
    } 
    checkedVM.getShortName(0, ref label);
    if (label == string.Empty)
    {
        label = "None";
    }
    checkedVM.SlotButtons = Convert.ToString(0 + ":" + label); // Setting CONTENT of radiobutton selected 
    
