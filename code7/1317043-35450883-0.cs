    List<string> categories = new List<string>();
    JArray data = JArray.Parse(jsonString);
    foreach (JObject entry in data.Children<JObject>())
    {
      foreach (JProperty p in entry.Properties())
      {
        if (p.Name.Equals("sub_category_en"))
        {
          string value = (string)p.Value;
          categories.Add(value);
        }
      }
    }
