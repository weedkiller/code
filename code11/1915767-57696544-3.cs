    TopicTaskConcurrentDictionary.Instance.CollectionChanged += delegate (object o, EventArgs e)
    {
      foreach (var item in TopicTaskConcurrentDictionary.Instance)
      {
        ;
      }
    };
    var dataService = _kernel.Get<IDataService>();
    TopicTaskConcurrentDictionary.Instance.TryAdd(new KeyValuePair<string, string>(param.TagPrefix, param.TopicName), dataService);
