        protected override void OnStart(string[] args)
        {
            _log.Debug("LoggingService starting.");
            
            _log.Debug("Initializing WatcherService.");
            _watcher = new FileSystemWatcher { Path = AppConfig.MonitorFolder, IncludeSubdirectories = true };
            _watcher.Created += File_OnChanged;      
            _watcher.EnableRaisingEvents = true; 
            _log.Debug("WatcherService started.");
            ThreadPool.QueueUserWorkItem(_watcher.ProcessExistingFiles, AppConfig.MonitorFolder);
        }
