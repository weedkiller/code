    public class Test
    {
        [Fact]
        public void MapDynamicToDictionary()
        {
            dynamic d = new { Nr = 1, Name = "Devon" };
            var dictionary = TurnObjectIntoDictionary(d);
            Assert.Equal(2, dictionary.Keys.Count);
        }
        [Fact]
        public void MapDictionaryToType()
        {
            dynamic d = new { Nr = 1, Name = "Devon" };
            var dictionary = TurnObjectIntoDictionary(d);
            var instance = new MyType();
            Map(dictionary, instance);
            Assert.Equal(instance.Nr, 1);
            Assert.Equal(instance.Name, "Devon");
        }
        public static void Map<T>(IDictionary<string, object> dictionary, T instance)
        {
            var attr = BindingFlags.Public | BindingFlags.Instance;
                foreach (var prop in instance.GetType().GetProperties(attr))
            {
                if (prop.CanWrite)
                {
                    if(dictionary.ContainsKey(prop.Name))
                    {
                        var v = Convert.ChangeType(dictionary[prop.Name], prop.PropertyType);
                        prop.SetValue(instance, v);                    }
                }
            }
        }
        public static IDictionary<string, object> TurnObjectIntoDictionary(object data)
        {
            var attr = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            foreach (var prop in data.GetType().GetProperties(attr))
            {
                if (prop.CanRead)
                {
                    dict.Add(prop.Name, prop.GetValue(data, null));
                }
            }
            return dict;
        }
    }
    class MyType
    {
        public int Nr { get; set; }
        public string Name { get; set; }
    }
