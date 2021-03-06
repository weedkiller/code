    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication3
    {
        class Program1
        {
            const string URL = "https://www.sciencedaily.com/rss/top/technology.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                List<Item> items = doc.Descendants("item").Select(x => new Item()
                {
                    title = (string)x.Element("title"),
                    link = (string)x.Element("link"),
                    description = (string)x.Element("description"),
                    _pubDate = (string)x.Element("pubDate"),
                    guid = (string)x.Element("guid")
                }).ToList();
            }
        }
        public class Item
        {
            public string title { get; set; }
            public string link { get; set; }
            public string description { get; set; }
            public DateTime pubDate { get; set; }
            public string _pubDate {
                get
                { return pubDate.ToString("ddd, dd MMM yyyy HH:mm:ss EDT"); }
                set { 
                    string[] splitDate = value.Split(new char[] { ',' });
                    pubDate = DateTime.ParseExact(splitDate[1].Trim(), "dd MMM yyyy HH:mm:ss EDT", CultureInfo.InvariantCulture);
                }
            }
            public string guid { get; set; }
        }
    }
                
