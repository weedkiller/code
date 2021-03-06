    private static void Main()
    {
        var input1 = new[] {"1", "2", "3"};
        foreach (var output in EnumeratePermutations(input1))
            Debug.WriteLine(String.Join(",", output));
    }
    private static IEnumerable<T[]> EnumeratePermutations<T>(T[] input)
    {
        return from partCount in Enumerable.Range(1, input.Length)
                let inputs = Enumerable.Repeat(input, partCount).ToArray()
                from indices in EnumerateCrossjoinIndices(inputs)
                where indices.Distinct().Count() == indices.Count()
                select indices.Select((n, i) => inputs[i][n]).ToArray();
    }
    private static IEnumerable<int[]> EnumerateCrossjoinIndices<T>(params T[][] inputs)
    {
        var indexer = new int[inputs.Length];
        var lastIncrementedIndex = inputs.Length - 1;
        while (lastIncrementedIndex >= 0)
        {
            yield return (int[]) indexer.Clone();
            lastIncrementedIndex = inputs.Length - 1;
            while (lastIncrementedIndex >= 0)
            {
                ++indexer[lastIncrementedIndex];
                if (indexer[lastIncrementedIndex] == inputs[lastIncrementedIndex].Length)
                {
                    indexer[lastIncrementedIndex] = 0;
                    --lastIncrementedIndex;
                }
                else
                    break;
            }
        }
    }
 
