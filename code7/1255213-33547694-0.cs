    public class OrderDto
    {
        public string ExternalId { get; set; }
        public Customer Customer { get; set;}
    }
    
    public class Customer
    {
        public string CustomerName { get; set; }
    }
