    private static IEnumerable<IObjectManager> FindManagers()
    {
      Type type = typeof(IObjectManager);
      IEnumerable<Type> managers = type.Assembly
                       .GetTypes()
                       .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(type));
      foreach (Type manager in managers)
      {
        var fi = manager.GetField("Instance", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        if (!fi.FieldType.IsGenericParameter)
        {
          yield return fi.GetValue(null);
        }
      }
    }
