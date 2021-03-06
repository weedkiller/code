    public class Person : IEquatable<Person>
    {
         public string Id { get; set; }
    
         public override bool Equals(object some) => Equals(some as Person);
         public override bool GetHashCode() => Id != null ? Id.GetHashCode() : 0;
         public bool Equals(Person person) => person != null && person.UniqueId == UniqueId;
    }
