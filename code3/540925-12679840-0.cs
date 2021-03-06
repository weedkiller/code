    //In Table Adapter    
    protected override void Dispose(bool disposing)
    {
	base.Dispose(disposing);
	Common.DisposeTableAdapter(disposing, _adapter, _commandCollection);
    }
    public static class Common
    {
	/// <summary>
	/// Disposes a TableAdapter generated by SQLite Designer
	/// </summary>
	/// <param name="disposing"></param>
	/// <param name="adapter"></param>
	/// <param name="commandCollection"></param>
	/// <remarks>You must dispose all the command,
    /// otherwise the file remains locked and cannot be accessed
    /// (for example, for reading or deletion)</remarks>
	public static void DisposeTableAdapter(
            bool disposing,
            System.Data.SQLite.SQLiteDataAdapter adapter,
            IEnumerable<System.Data.SQLite.SQLiteCommand> commandCollection)
	{
		if (disposing) {
			DisposeSQLiteTableAdapter(adapter);
			foreach (object currentCommand_loopVariable in commandCollection) {
				currentCommand = currentCommand_loopVariable;
				currentCommand.Dispose();
			}
		}
	}
	public static void DisposeSQLiteTableAdapter(
            System.Data.SQLite.SQLiteDataAdapter adapter)
	{
		if (adapter != null) {
			DisposeSQLiteTableAdapterCommands(adapter);
			adapter.Dispose();
		}
	}
	public static void DisposeSQLiteTableAdapterCommands(
            System.Data.SQLite.SQLiteDataAdapter adapter)
	{
		foreach (object currentCommand_loopVariable in {
			adapter.UpdateCommand,
			adapter.InsertCommand,
			adapter.DeleteCommand,
			adapter.SelectCommand
		}) {
			currentCommand = currentCommand_loopVariable;
			if (currentCommand != null) {
				currentCommand.Dispose();
			}
		}
	}
}
