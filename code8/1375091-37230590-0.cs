         if ((c.Contains("tell me about")) || (c.Contains("Tell me about")))
            {
                string query = c;
                string[] lines = Regex.Split(query, "about ");
                foreach (string line in lines)
                {
                
                string url = ("http://lookup.dbpedia.org/api/search.asmx/KeywordSearch?QueryString=" + line + "&MaxHits=1");
                    XmlReader reader = XmlReader.Create(url);
                    while (reader.Read())
                        switch (reader.Name.ToString())
                        {
                            case "Description":
                                sp(reader.ReadString());
                                break;
                        }
                }
