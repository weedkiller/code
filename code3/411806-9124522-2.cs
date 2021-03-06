    namespace StackOverflowConsole
    {
        using System;
        using System.IO;
        using System.Data;
        class Program
        {
            static void Main(string[] args)
            {
                var path = @"C:\temp\test.csv";
                CreateTestFile(path);
                var dataTable = new DataTable();
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Age", typeof(int));
                dataTable.Columns.Add("Salary", typeof(decimal));
                // TODO: add checks, exception handling
                using (var reader = new StreamReader(path))
                {
                    // reads all lines into a single string
                    var lines = reader.ReadToEnd().Split(new char[] { '\n' });
                    if (lines.Length > 0)
                    {
                        // you may wanna skip the first line, if you're using a file header
                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }
                            // split the current line using the separator
                            var tokens = line.Trim().Split(new char[] { ',' });
                        
                            // check your assumptions on the CSV contents
                            // ex: only process lines with the correct number of fields
                            if (tokens.Length == 3)
                            {
                                var person = new Person();
                                person.Name = tokens[0];
                                // a better implementation would use TryParse()
                                person.Age = Int32.Parse(tokens[1]);
                                person.Salary = Decimal.Parse(tokens[2]);
                                dataTable.Rows.Add(person.Name, person.Age, person.Salary);
                            }
                        }
                    }
                }
            }
            private static void CreateTestFile(string path)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (var writer = new StreamWriter(path))
                {
                    writer.WriteLine("A,30,1000");
                    writer.WriteLine("B,35,1500");
                    writer.WriteLine("C,40,2000");
                }
            }
        }
        public class Person
        {
            public string Name;
            public int Age;
            public decimal Salary;
        }
    }
