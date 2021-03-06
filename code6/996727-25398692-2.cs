    public class House
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Room> rooms { get; set; }
    
        public House()
        {
            rooms = new List<Room>();
        }
    }
    
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int roomNumber { get; set; }
        public int HouseId {get; set; }
        public virtual House house { get; set; }
    }
