        internal class ProcessedLine
        {
            public string Original { get; private set; }
            public string[] Trimmed { get; private set; }
            public ProcessedLine(string original)
            {
                Original = original;
                Trimmed = Original.Split(';').Select(x => x.Trim()).ToArray();
            }
            public string SortKey1
            {
                get { return Trimmed[4]; }
            }
            public string SortKey2
            {
                get { return Trimmed[1]; }
            }
            public string JoinedTrimmed
            {
                get { return string.Join(";", Trimmed); }
            }
        }
