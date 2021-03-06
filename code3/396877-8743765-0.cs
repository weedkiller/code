    public static List<string> RecentAssetList   
    {   
        get   
        {   
            if (HttpContext.Current.Session["RECENT_ASSET_LIST"] == null)
                HttpContext.Current.Session["RECENT_ASSET_LIST"] = new List<string>();
    
            return HttpContext.Current.Session["RECENT_ASSET_LIST"].ToString();   
        }   
        set   
        {   
            HttpContext.Current.Session["RECENT_ASSET_LIST"] = value;   
        }   
    }   
    List<string> assetList = SessionData.RecentAssetList;             
    assetList.Add(assetId.ToString());     
    SessionData.RecentAssetList = assetList; // otherwise it's not changed in the session, you can write an extension method where you can add it to the list and submit that list to the session at the same time
