        public static double GetTemperatureFromUser()
        {
             while (true)
             {
                  Console.Write("Enter temperature in Fahrenheit: ");
                  var t = FahrToCels(Convert.ToDouble(Console.ReadLine()));
              
                  if (t < 73)
                  {
                      Console.Write("Temperature is too low. Try again.");
                  }
                  else if (t > 77)
                  {
                      Console.Write("Temperature is too high. Try again.");
                  }
                  else
                  {
                      return t;
                  }
             }
        }
