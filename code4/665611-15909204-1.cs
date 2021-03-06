    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TThird, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            IEnumerable<TThird> third,
            Func<TFirst, TSecond, TThird, TResult> resultSelector )
        {
            if( first == null )
                throw new ArgumentNullException( "first cannot be null" );
            if( second == null )
                throw new ArgumentNullException( "second cannot be null" );
            if( third == null )
                throw new ArgumentNullException( "third cannot be null" );
            if(resultSelector == null)
                throw new ArgumentNullException( "resultSelector cannot be null" );
         
            using ( var iterator1 = first.GetEnumerator() )
            using ( var iterator2 = second.GetEnumerator() )
            using ( var iterator3 = third.GetEnumerator() )
            {
                while ( iterator1.MoveNext() && iterator2.MoveNext() && iterator3.MoveNext() )
                {
                    yield return resultSelector(
                        iterator1.Current,
                        iterator2.Current,
                        iterator3.Current );
                }
            }
        }
    }
