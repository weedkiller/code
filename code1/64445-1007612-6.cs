    private void ConfigureMainMenu(DIServer server)
    {
        MenuStrip mnMnu = PresenterView.MainMenu;
        if (mnMnu.InvokeRequired)
        {
            // Private variable
            _methodInvoker = new MethodInvoker((Action)(() => ConfigureMainMenu(server)));
            _methodInvoker.BeginInvoke(new AsyncCallback(ProcessEnded), null); // Call _methodInvoker.EndInvoke in ProcessEnded
        }
        else
        {
            /* do work */
        }
    }
