    public static IEnumerable<T> 
        Join<T>(this IEnumerable<T> src, Func<T> separatorFactory)
    {
        var srcArr = src.ToArray();
        for (int i = 0; i < srcArr.Length; i++)
        {
            yield return srcArr[i];
            if(i<srcArr.Length-1)
            {
                yield return separatorFactory();
            }
        }
    }
