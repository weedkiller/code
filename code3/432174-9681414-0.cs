        if (!myCheckBox.Dispatcher.CheckAccess())
    {
      myCheckBox.Dispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Normal,
        new Action(
          delegate()
          {
            myCheckBox.IsChecked = true;
          }
      ));
    }
    else
    {
      myCheckBox.IsChecked = true;
    }
