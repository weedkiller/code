    public class DataTableRequest
    {
        // the list of existing properties here
        public List<object> Data {get; set;}
        public IEnumerable<Species> Species
        {
            get { return this.Data.OfType<Species>(); }
        }
        public IEnumerable<Chemical> Chemicals
        {
            get { return this.Data.OfType<Chemical>(); }
        }
    }
