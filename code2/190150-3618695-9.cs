        /// <summary>
        /// Represents an Person collection.
        /// </summary>
        [Serializable]
        [XmlRoot("Persons", IsNullable = false)]
        public sealed class Persons
        {
            /// <summary>
            /// The person collection.
            /// </summary>
            private Collection<Person> persons;
            /// <summary>
            /// Initializes a new instance of the <see cref="Persons"/> class.
            /// </summary>
            /// <param name="persons">The person list.</param>
            public Persons(Collection<Person> persons)
            {
                this.persons = persons;
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="Persons"/> class.
            /// </summary>
            /// <param name="persons">The person array.</param>
            public Persons(Person[] persons)
                : this(new Collection<Person>(persons))
            {
            }
            /// <summary>
            /// Prevents a default instance of the <see cref="Persons"/> class from being created.
            /// </summary>
            private Persons()
            {
            }
            /// <summary>
            /// Copies the collection of Person objects to an array and returns
            /// it.
            /// </summary>
            /// <returns>An array of Person objects based on the
            /// collection.</returns>
            public Person[] ToArray()
            {
                Person[] personArray = new Person[this.persons.Count];
                this.persons.CopyTo(personArray, 0);
                return personArray;
            }
            /// <summary>
            /// Gets or sets the persons.
            /// </summary>
            /// <value>The persons.</value>
            [XmlElement("Person")]
            public Collection<Person> ThePersons
            {
                get
                {
                    return this.persons;
                }
                set
                {
                    this.persons = value;
                }
            }
            /// <summary>
            /// Gets the length of the persons.
            /// </summary>
            /// <value>The length of the persons.</value>
            [XmlIgnore]
            public int Length
            {
                get
                {
                    return this.persons.Count;
                }
            }
            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>A <see cref="IEnumerator&lt;Person&gt;"/> that can be used to
            /// iterate through the collection.</returns>
            public IEnumerator<Person> GetEnumerator()
            {
                return (IEnumerator<Person>)this.persons.GetEnumerator();
            }
        }
