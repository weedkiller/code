    class Program
    {
        public static readonly ReadOnlyDictionary<char, LetterImage> dictionary;
        static Program()
        {
            var mutable = new Dictionary<char, LetterImage>();
            dictionary = new ReadOnlyDictionary<char, LetterImage>(mutable)
        }
    }
