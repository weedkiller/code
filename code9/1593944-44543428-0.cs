    public class YourModel: INotifyPropertyChanged
    {
         private ObservableCollection<string> _drivers;
         public ObservableCollection<string> Drivers
         {
             get { return _drivers; }
             set
             {
                if (Equals(value, _drivers)) return;
                _drivers= value;
                OnPropertyChanged(nameof(Drivers));
             }
         }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
