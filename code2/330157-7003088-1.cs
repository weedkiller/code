    var myClickDelegate = (RoutedEventHandler)delegate { clicked(z2, null); };
    
    PicBx[z].Click += myClickDelegate;
    
    ...
    
    PicBx[z].Click -= myClickDelegate;
