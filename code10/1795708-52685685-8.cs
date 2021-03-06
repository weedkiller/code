    public static class Settings
    {
        public delegate void SettingsChangedEventHandler(object sender, SettingsEventArgs e);
        public static event SettingsChangedEventHandler SettingsChanged;
        private static TH th;
        private static int m_Other;
        public class SettingsEventArgs : EventArgs
        {
            private TH m_value;
            public SettingsEventArgs(TH m_v) => m_value = m_v;
            public TH THValue { get => m_value; set => m_value = value; }
            public int Other { get => m_Other; set => m_Other = value; }
        }
        public static void OnSettingsChanged(SettingsEventArgs e) => 
            SettingsChanged?.Invoke("Settings", e);
        public static TH THProperty
        {
            get => th;
            set { th = value; OnSettingsChanged(new SettingsEventArgs(th)); }
        }
    }
