    private static string textFormater2(string input)
        {
            string[] lines = Regex.Split(input, "\r\n");
            int tabCount = 0;
            StringBuilder output = new StringBuilder();
            using (StringReader sr = new StringReader(input))
            {
                string l;
                while (!string.IsNullOrEmpty(l = sr.ReadLine()))
                {
                    if (l.Substring(0, 1) == "[")
                        if (l.Contains('/'))
                            tabCount--;
                    string tabs = string.Empty;
                    for (int i = 0; i < tabCount; i++)
                        tabs += "\t";
                    output.AppendLine(tabs + l);
                    if (l.Substring(0, 1) == "[")
                        if (!l.Contains('/'))
                            tabCount++;
                }
            }
            return output.ToString();
        }
