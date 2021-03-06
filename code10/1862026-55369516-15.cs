    public static class TaskUtils
    {
    #pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
       public static async void FireAndForgetSafeAsync(this Task task,  Action<Exception> onErrors = null)
    #pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
       {
          try
          {
             await task;
          }
          catch (Exception ex)
          {
             onErrors?.Invoke(ex);
          }
       }
    }
