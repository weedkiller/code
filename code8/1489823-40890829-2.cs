       static void Main(string[] args) {
         // better practice is paths combining
         string path = Path.Combine(Environment.SpecialFolder.Desktop, "list.txt");
         // unique (no duplicates) strings so far
         HashSet<String> hash = new HashSet<string>(
           File.ReadLines(path), // file to read from
           StringComparer.OrdinalIgnoreCase); // let's ignore words' case ("World", "world")
    
         Console.WriteLine("New Word: ");
    
         string newWord = Console.ReadLine().Trim(); // let's trim spaces: "world " -> "world"
    
         if (!string.IsNullOrEmpty(newWord)) // let's not add an empty string
           if (!hash.Contains(newWord)) {
             // add new word to the end of file
             File.AppendAllLines(path, new string[] {newWord});
    
             Console.WriteLine("New word has been added!");
           } 
           else 
             Console.WriteLine("It already exists! Input another word");
         else
           Console.WriteLine("We don't add empty lines."); 
         Console.ReadKey();
       }
