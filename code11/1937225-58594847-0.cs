public static IEnumerable<PhraseSource> GetPhraseSources(IEnumerable<CategorySource> categorySources)
{
    return App.DB.db1.Table<PhraseSource>().
        Select(item => {
            item.OneHash = Math.Abs(item.Id.GetHashCode() % 10);
            item.TwoHash = Math.Abs(item.Id.GetHashCode() % 20);
            item.ThreeHash = Math.Abs(item.Id.GetHashCode() % 50);
            return item;
        });
}
Then you can call `.ToList()` _after_ calling the method if you _really_ need a list instead of an enumerable (hint: you usually don't)
I'm also curious what the `categorySources` input is for, since it doesn't seem to be used in the function.
