    private string _selectedItem;
    public string SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            PropertyChangedEvent.Notify(this,"SelectedItem");
        }            
    }
