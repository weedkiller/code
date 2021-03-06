    public string CalculateMD5Hash(string input)
    {
            // step 1, calculate MD5 hash from input
            using(MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
               byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
               byte[] hash = md5.ComputeHash(inputBytes);
         
               // step 2, convert byte array to hex string
               StringBuilder sb = new StringBuilder(2 * hash.Length);
               for (int i = 0; i < hash.Length; i++)
               {
                  // use "x2" for all lower case.
                  sb.Append(hash[i].ToString("X2"));
               }
               return sb.ToString();
            }
    }
       
