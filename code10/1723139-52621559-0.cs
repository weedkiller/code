    public class Student
    {
        public Student() { }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
    }
    public class StudentAddress
    {
        [ForeignKey("Student")]
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual Student Student { get; set; }
    }
