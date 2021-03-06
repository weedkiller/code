    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = this.PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
