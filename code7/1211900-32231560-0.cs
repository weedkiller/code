    public static class StringExtensions
    {
        public static string RemoveParentheses(this string value)
        {
            var cantrim = false;
            var openparenthesesIndex = new Stack<int>();
            var count = 0;
            foreach (char c in value)
            {
                if (c == '(')
                {
                    openparenthesesIndex.Push(count);
                }
                if (c == ')')
                {
                    cantrim = (count == value.Length - 1 && openparenthesesIndex.Count == 1 && openparenthesesIndex.Peek() == 0);
                    openparenthesesIndex.Pop();
                }
                count++;
            }
    
            if (cantrim)
            {
                return value.Trim(new[] { '(', ')' });
            }
            return value;
        }
    }
