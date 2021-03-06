    using System.Threading.Tasks;
    namespace AsyncAwaitCL
    {
        public class AsyncHelpers
        {
            public static async Task<T> RunMethodAsync<T>(Task<T> task)
            {
                T returnValue = default(T);
                returnValue = await task;
                return returnValue;
            }
        }
    }
