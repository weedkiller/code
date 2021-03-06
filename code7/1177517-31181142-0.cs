    public sealed class ApplicationSettingsManager
    {
        readonly object app;
        readonly Dictionary<string, object> appSettings;
        public ApplicationSettingsManager(object app)
        {
            this.app = app;
        }
        public object Application { get { return app; } }
        public void SaveSetting(string setting)
        {
            var propInfo = app.GetType().GetProperty(setting);
            if (propInfo == null)
                throw new ArgumentException("No such property.");
            var value = propInfo.GetValue(app);
            
            if (appSettings.ContainsKey(setting))
            {
                appSettings[setting] = value;
            }
            else
            {
                appSettings.Add(setting, value);
            }
        }
        public void RestoreSetting(string setting)
        {
            if (!appSettings.ContainsKey(setting))
                return;
            var propInfo = app.GetType().GetProperty(setting);
            propInfo.SetValue(app, appSettings[setting]);
        }
        public void RestoreAllSettingas()
        {
            foreach (var p in appSettings)
            {
                RestoreSetting(p.Key);
            }
        }
    }
