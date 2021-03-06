    public class MyData
    {
        public MyData() 
        {
           this.Properties = new Dictionary<string,string>();
        }
        public string ID { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
    public static void Main(string[] args)
    {
        IEnumerable<MyData> myDataList = new List<MyData>();
        int index = 0; // Assuming your starting point is 0
        foreach (var obj in myDataList)
        {
            if (obj != null && string.IsNullOrEmpty(obj.ID))
            {
                obj.ID = index.ToString();
                // Checks if the Properties dictionary has the key "id"
                if (obj.Properties.ContainsKey("id"))
                {
                   // If it does, then update it
                   obj.Properties["id"] = obj.ID;
                }
                else
                {
                   // Else add it to the dictionary
                   obj.Properties.Add("id", obj.ID);
                }
            }
            index++;
        }
