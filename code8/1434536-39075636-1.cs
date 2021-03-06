    public class Employee
    {    
       public int Id {get;set;}
       public string Firstname => Person.FirstName;
       public Person Person {get;private set;}
       // this ctor is set to private to prevent construction of object with default constructor
       private Employee() {}
  
       public Employee(Person person) 
       { 
           this.Person = person;
       }
    }
    
    public class Person
    {
       // We add property to Person as it's more generic class than Employee
       public string Firstname {get;set;}
    }
