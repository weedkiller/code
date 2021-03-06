    public static class ExtentionMethods
    {
        public static void Update<TItem, TValue>(this IEnumerable<TItem> @this, IEnumerable<TValue> items, Action<TItem, TValue> applyAction) 
            where TItem : class
        {
            using (var thisEnumerator = @this.GetEnumerator())
            using (var itemEnumerator = items.GetEnumerator())
            {
                while (thisEnumerator.MoveNext() && itemEnumerator.MoveNext())
                {
                    applyAction(thisEnumerator.Current, itemEnumerator.Current);
                }
            }
        }
        public delegate void UpdateAction<TItem, TValue>(ref TItem item, TValue newValue);
        public static void Update<TItem, TValue>(this IList<TItem> @this, IEnumerable<TValue> items, UpdateAction<TItem, TValue> applyAction)
    where TItem : struct 
        {
            using (var itemEnumerator = items.GetEnumerator())
            {
                for (int i = 0; i < @this.Count && itemEnumerator.MoveNext(); i++)
                {
                    var temp = @this[i];
                    applyAction(ref temp, itemEnumerator.Current);
                    @this[i] = temp;
                }
            }
        }
    }
