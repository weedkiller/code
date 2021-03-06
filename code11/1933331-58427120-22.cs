      using System.Linq;
      using System.Text.RegularExpressions;
      ...
      string text = 
        @"Text with punctuation: comma, full stop. Apostroph's and ""quotation?"" - ! Yes!";
      string[] words = Regex
        .Matches(text, @"[\p{L}']+") // Let word be one or more letters or apostrophs
        .Cast<Match>()
        .Select(match => match.Value)
        .Concat(new string[] { "addThis"})
        .ToArray();
      Console.Write(string.Join(Environment.NewLine, result));
