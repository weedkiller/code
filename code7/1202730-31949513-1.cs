    public static class Helpers
    {    
        public static T Deserialize<T>(this string SerializedJSONString)
        {
            var stuff = JsonConvert.DeserializeObject<T>(SerializedJSONString);
            return stuff;
        }
    }
    string jsonresult = await WCFRESTServiceCall("GET", "cinema_city");    
    var data = Helper.Deserialize<Citys>(jsonresult);    
    var dialog = new MessageDialog(jsonresult);
    await dialog.ShowAsync();
