    public int M(Expression<Func<Person, int?>> selector)
    {
        var expr = Expression.NotEqual(selector.Body, Expression.Constant(null, typeof(object)));
        var lambda = Expression.Lambda<Func<Person, bool>>(expr, selector.Parameters);
        return (Dc.ListPeople(lambda)
        .DefaultIfEmpty()
        .Max(Expression.Lambda<Func<Person, int?>>(selector.Body, selector.Parameters)) ?? 0) + 1;
    }
