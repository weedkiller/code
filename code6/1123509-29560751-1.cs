    public void ReadXml(XmlReader reader)
    {
        // no need to advace upfront so MoveToContent was taken out (would 
        // mess with subsequent inner deserializations anyway)
        if (reader.Name == "FamilyTree")
        {
            do
            {
                if (reader.Name == "Member" && reader.IsStartElement())
                {
                    Type type = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(x => x.Name == reader.Name)
                    .FirstOrDefault();
                    if (type != null)
                    {
                        var xmlSerializer = new XmlSerializer(type);
                        var member = (IMember)xmlSerializer.Deserialize(reader);
                        this.Add(member);
                    }
                    continue; // to omit .Read because Deserialize did already 
                              // advance us to next element
                }
    
                if (reader.Name == "FamilyTree" && reader.NodeType == System.Xml.XmlNodeType.EndElement)
                    break;
    
                reader.Read();
            }
            while (!reader.EOF);
        }
    }
