    private void CreateTaskPane<T>(string title) where T : UserControl, new()
    {
        T taskPaneView = new T();
        taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(taskPaneView, title);
        taskPane.Visible = true;
    }
