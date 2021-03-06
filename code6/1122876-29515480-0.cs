    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace YourNameSpace
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person p = GetPersonFromUserInput();
            }
    
            private static Person GetPersonFromUserInput()
            {
                Person p = new Person();
                Type t = typeof(Person);
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    Console.Write("{0}: ", pi.GetCustomAttribute<PromptAttribute>().Prompt);
                    
                    if (pi.PropertyType == typeof(int))
                    {
                        int userInput;
                        while (!int.TryParse(Console.ReadLine(),out userInput))
                        {
                            Console.Write("You have to enter an integer: ");
                        }
    
                        pi.SetMethod.Invoke(p, new object[] { userInput });
                    }
                    else if (pi.PropertyType == typeof(string))
                    {
                        string userInput = Console.ReadLine();
                        pi.SetMethod.Invoke(p, new object[] { userInput });
    
                    } //add more types in this manner
                }
    
                return p;
            }
    
    
        }
    
        public class Person
        {
            [Prompt("Please enter the persons firstname")]
            public string FirstName { get; set; }
    
            [Prompt("Please enter the persons surname")]
            public string SurName { get; set; }
            
            [Prompt("Please enter the persons haircolor")]
            public string HairColor { get; set; }
    
            [Prompt("Please enter the persons eyecolor")]
            public string EyeColor { get; set; }
    
            [Prompt("Please enter the persons weight")]
            public int Weight { get; set; }
    
            [Prompt("Please enter the persons height")]
            public int Height { get; set; }
    
            [Prompt("Please enter the persons age")]
            public int Age { get; set; }
        }
    
        public class PromptAttribute : Attribute
        {
            public string Prompt { get; private set; }
    
            public PromptAttribute(string prompt)
            {
                Prompt = prompt;
            }
        }
    }
