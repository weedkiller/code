    public static class StringBuilderExtension
    {
        public static void AppendIfNotNull<TValue>(this StringBuilder sb, TValue value, Func<TValue, string> transform)
            where TValue : class 
        {
            if (value != null)
            {
                sb.Append( transform( value ));
            }
        }
    }
