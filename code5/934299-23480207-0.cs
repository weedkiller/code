    public static void WriteFile()
    {
        Car testCar= new Car();
        string path = "c:\temp\testCarPath.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Car));
        StreamWriter file = new StreamWriter(path);
        serializer.Serialize(file, testCar);
        file.Close();
    }
    public static void ReadFile()
    {
        Car testCar;
        string path = "c:\temp\testCarPath.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Car));
        StreamReader reader = new StreamReader(path);
        testCar = (Car)serializer.Deserialize(reader);
        reader.Close();
    }
