    /// somewhere on global
    object loggerLock = new object(); 
        ....
        lock(loggerLock )
        {
            Logger.LogEvent(String.Format("GlobalCache sent to client {0} [IP:{1}]", clientGUID.ToString(), HttpContext.Current.Request.UserHostAddress.ToString()));**
        }
        if (GlobalEntities.CacheData == null) DBAccess.GetData();
        //Return our server guid
        serverGUID = GlobalEntities.ServerGUID;
        return GlobalEntities.CacheData;
    }
