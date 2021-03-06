    private static void Main(string[] args)
    {
        List<int> set = new List<int>
        {
            20, 4, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        var permutes = Permute(set);
        Console.WriteLine(permutes.Count); // outputs 58140
    }
    private static List<int[]> Permute(List<int> set)
    {
        List<int[]> result = new List<int[]>(); 
        Action<int> permute = null;
        permute = start =>
        {
            if (start == set.Count)
            {
                result.Add(set.ToArray());
            }
            else
            {
                List<int> swaps = new List<int>();
                for (int i = start; i < set.Count; i++)
                {
                    if (swaps.Contains(set[i])) continue; // skip if we already done swap with this item
                    swaps.Add(set[i]);
                    Swap(set, start, i);
                    permute(start + 1); 
                    Swap(set, start, i);
                }
            }
        };
        permute(0);
        return result;
    }
    private static void Swap(List<int> set, int index1, int index2)
    {
        int temp = set[index1];
        set[index1] = set[index2];
        set[index2] = temp;
    }
