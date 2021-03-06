    [JsonConverter(typeof(EntryConverter))]
    public class Entry
    {
        public Entry()
        {
            // You need to determine whether the time numbers in the JSON are in UTC or in the timezone given in the "TimeZone" field.  If
            // Local, change to DateTimeKind.Local
            DateTime = new DateTime(0, DateTimeKind.Utc); 
        }
        public DateTime DateTime { get; set; }
        public int Number { get; set; } // That 3600 thing.  No idea what it's for.
        public string Destination { get; set; }
        public string TimeZone { get; set; }
        // Not all time zone offsets are integers: https://en.wikipedia.org/wiki/UTC%E2%88%9204:30
        public decimal GmtOffset { get; set; }
    }
