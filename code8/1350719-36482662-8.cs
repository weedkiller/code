    class Station
    {
        public string station_code { get; set; }
        public string name  { get; set; }
        // other fields...
    }
    class Model
    {
        public IList<object> stations { get; set; }
        // other fields...
    }
    var jsonObject = JsonConvert.DeserializeObject<Model>(localJson);
    foreach (var stationCode in jsonObject.stations)
    {
        Console.WriteLine(station.station_code);
    }
