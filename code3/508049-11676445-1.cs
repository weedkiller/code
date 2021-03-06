    //...
    dbTool = new DBTool();
    // Initialize the connection string
    // Disable some UI
    Thread thread = new Thread(new ThreadStart(
            delegate()
            {
                dbTool.connectToDB();
                UIControl.Dispatcher.BeginInvoke(
                  new Action(
                      updateAfterValidation
                ));
            }
        ));
    thread.Start();
    
    //.....
    
    void updateAfterValidation()
    {
        if (dbTool.validString)     // If the connection string was valid
        {
            // Re-enable controls
        }
        else     // Invalid connection string
        {
            // Keep controls disabled if no connection could be created
        }
    }
