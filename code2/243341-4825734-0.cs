    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    public static class QueryHacks
    {
        public static readonly HackToken TransferToClient = HackToken.Instance;
        
        public static IEnumerable<T> Where<T>(
            this IQueryable<T> source,
            Func<T, HackToken> ignored)
        {
            // Just like AsEnumerable
            return source;
        }
        
        public class HackToken
        {
            internal static readonly HackToken Instance = new HackToken();
            private HackToken() {}
        }
    }
    
    public class Test
    {
        static void Main()
        {
            // Pretend this is really a db context or whatever
            IQueryable<string> source = new string[0].AsQueryable();
            
            var query = from x in source
                        where x.StartsWith("Foo") // Queryable.Where
                        where QueryHacks.TransferToClient
                        where x.GetHashCode() == 5 // Enumerable.Where
                        select x.Length;
        }
    }
