    public class IisExpress : IDisposable
    {
        private Boolean _isDisposed;
        private Process _process;
        public void Dispose()
        {
            Dispose(true);
        }
        public void Start(String directoryPath, Int32 port)
        {
            var iisExpressPath = DetermineIisExpressPath();
            var arguments = String.Format(
                CultureInfo.InvariantCulture, "/path:\"{0}\" /port:{1}", directoryPath, port);
            var info = new ProcessStartInfo(iisExpressPath)
                                        {
                                            WindowStyle = ProcessWindowStyle.Normal,
                                            ErrorDialog = true,
                                            LoadUserProfile = true,
                                            CreateNoWindow = false,
                                            UseShellExecute = false,
                                            Arguments = arguments
                                        };
            var startThread = new Thread(() => StartIisExpress(info))
                                     {
                                         IsBackground = true
                                     };
            startThread.Start();
        }
        protected virtual void Dispose(Boolean disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                if (_process.HasExited == false)
                {
                    _process.Kill();
                }
                _process.Dispose();
            }
            _isDisposed = true;
        }
        private static String DetermineIisExpressPath()
        {
            String iisExpressPath;
            iisExpressPath = Environment.GetFolderPath(Environment.Is64BitOperatingSystem 
                ? Environment.SpecialFolder.ProgramFilesX86
                : Environment.SpecialFolder.ProgramFiles);
            iisExpressPath = Path.Combine(iisExpressPath, @"IIS Express\iisexpress.exe");
            return iisExpressPath;
        }
        private void StartIisExpress(ProcessStartInfo info)
        {
            try
            {
                _process = Process.Start(info);
                _process.WaitForExit();
            }
            catch (Exception)
            {
                Dispose();
            }
        }
    }
