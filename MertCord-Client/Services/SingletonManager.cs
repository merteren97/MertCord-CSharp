namespace MertCord_Client.Services
{
    public class SingletonManager<T> where T : new()
    {
        static T? singletonManager;
        static object _lock = new object();
        public static T Instance()
        {
            lock (_lock)
            {
                if (singletonManager == null)
                    singletonManager = new T();
                return singletonManager;
            }
        }
    }
}