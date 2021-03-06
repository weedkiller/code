    public enum FilterOperator
    {
        [EnumMember(Value = "eq")]
        Equals,
        [EnumMember(Value = "gt")]
        GreaterThan,
        [EnumMember(Value = "lt")]
        LessThan,
        [EnumMember(Value = "in")]
        In,
        [EnumMember(Value = "like")]
        Like
    }
    public class GridFilter
    {
        [JsonProperty("operator")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilterOperator Operator { get; set; }
    }
    [TestMethod]
    public void enumTest()
    {
        GridFilter gf = new GridFilter()
        {
            Operator = FilterOperator.Equals
        };
        var json = JsonConvert.SerializeObject(gf);
       // json yields {"operator":"eq"}
    }
