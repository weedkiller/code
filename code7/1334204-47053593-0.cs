    private static ServerEntry serverEntry = null;
            public static ServerEntry SelectedServerEntry
            {
                get
                {
                    if (serverEntry == null)
                        serverEntry = ServerManagerApi.LoadServer("xxx.dll");
                    return serverEntry;
                }
            }
    public static ServerEntry LoadServer(string path)
            {
                try
                {
                    //  Create a server entry for the server.
                    var serverEntry = new ServerEntry();
    
                    //  Set the data.
                    serverEntry.ServerName = Path.GetFileNameWithoutExtension(path);
                    serverEntry.ServerPath = path;
    
                    //  Create an assembly catalog for the assembly and a container from it.
                    var catalog = new AssemblyCatalog(Path.GetFullPath(path));
                    var container = new CompositionContainer(catalog);
    
                    //  Get the exported server.
                    var server = container.GetExport<ISharpShellServer>().Value;
    
                    serverEntry.ServerType = server.ServerType;
                    serverEntry.ClassId = server.GetType().GUID;
                    serverEntry.Server = server;
    
                    return serverEntry;
                }
                catch (Exception)
                {
                    //  It's almost certainly not a COM server.
                    MessageBox.Show("The file '" + Path.GetFileName(path) + "' is not a SharpShell Server.", "Warning");
                    return null;
                }
            }
