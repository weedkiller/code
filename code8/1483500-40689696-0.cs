        private static string GeneratenewRandom()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                GeneratenewRandom();
            }
            return r;
        }
        
