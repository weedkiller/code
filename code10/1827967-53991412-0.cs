            public static void Main(string[] args)
            {
                string[] rejectableStrings = new string[] {"fox", "dog", "farmer"};
                string[] allowableStrings = new string[] {"quick red fox", "smurfy blue fox", "lazy brown dog", "old green farmer"};
                string teststr = "fox quick red fox";
                bool pass = true;
                foreach (string allowed in allowableStrings)
                {
                    teststr = teststr.Replace(allowed, "");
                }
                foreach (string reject in rejectableStrings)
                {
                    if (Regex.Matches(teststr, reject).Count > 0) {
                        pass = false;
                    }
                }
                Console.WriteLine(pass);
            }
