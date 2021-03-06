    public static class IEnumerableExt {
        public static int SeqCompareTo<T>(this IEnumerable<T> s1, IEnumerable<T> s2) => SequenceCompare(s1, s2);
    
        public static int SequenceCompare<T>(IEnumerable<T> source1, IEnumerable<T> source2) {
            // You could add an overload with this as a parameter
            IComparer<T> elementComparer = Comparer<T>.Default;
            using (IEnumerator<T> iterator1 = source1.GetEnumerator())
            using (IEnumerator<T> iterator2 = source2.GetEnumerator()) {
                while (true) {
                    bool next1 = iterator1.MoveNext();
                    bool next2 = iterator2.MoveNext();
                    if (!next1 && !next2) // Both sequences finished
                        return 0;
                    if (!next1) // Only the first sequence has finished
                        return -1;
                    if (!next2) // Only the second sequence has finished
                        return 1;
                    // Both are still going, compare current elements
                    int comparison = elementComparer.Compare(iterator1.Current,
                                                             iterator2.Current);
                    // If elements are non-equal, we're done
                    if (comparison != 0)
                        return comparison;
                }
            }
        }
    }
    
    public class SeqCompare<T> : IComparer<IEnumerable<T>> {
        public int Compare(IEnumerable<T> x, IEnumerable<T> y) => x.SeqCompareTo(y);
    }
