    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
    }
    [Test]
    public void CanMapMatchingFieldNamesWithEase()
    {
        // Arrange
        var dictionary = new Dictionary<string, object>
                                {
                                    { "Id", 1 },
                                    { "FirstName", "Clark" },
                                    { "LastName", "Kent" }
                                };
        // Act
        var person = Slapper.AutoMapper.Map<Person>( dictionary );
        // Assert
        Assert.NotNull( person );
        Assert.That( person.Id == 1 );
        Assert.That( person.FirstName == "Clark" );
        Assert.That( person.LastName == "Kent" );
    }
