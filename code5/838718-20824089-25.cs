    var xmlSerializableDictionary = new XmlSerializableDictionary<DimensionInfo>
    {
        {"justakey", new DimensionInfo {Enabled = true}},
        {"anotherkey", null}
    };
    var xmlSerializer = new XmlSerializer(typeof (SerializableDictionary<DimensionInfo>));
    xmlSerializer.Serialize(File.Open(@"D:\xmlSerializedDictionary.xml", FileMode.Create), serializableDictionary);
