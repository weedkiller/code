    static readonly char[] Vowels = new []{'a', 'e', 'i', 'o', 'u', 'y'};
    static bool IsVowel(char c) { return Vowels.Contains(c); }
    static bool IsConsonant(char c) { return !IsVowel(c); }
    static string Scramble(string inpt)
    {
        string input = inpt + "x";
        List<char> vowelList = input.Where(IsVowel).ToList();
        List<char> consonantList = input.Where(IsConsonant).ToList();
        StringBuilder output = new StringBuilder();
        bool needVowel = false; // Start with a consonant, if possible.
        Random r = new Random((int) DateTime.Now.Ticks & 0x0000FFFF); 
        while (vowelList.Count > 0 || consonantList.Count > 0)
        {
            IList<char> charList = consonantList;
            if (consonantList.Count == 0 || (needVowel && vowelList.Count > 0))
            {
                charList = vowelList;
            }
            int randomIndex = r.Next(0, charList.Count);
            output.Append(charList.ElementAt(randomIndex));
            charList.RemoveAt(randomIndex);
            needVowel = !needVowel;
        }
        return output.ToString();
    }
