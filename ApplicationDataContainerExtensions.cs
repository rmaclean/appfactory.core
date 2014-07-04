namespace appfactory.core
{
    using Windows.Storage;

    public static class ApplicationDataContainerExtensions
    {
        public static T Read<T>(this ApplicationDataContainer container, string key, T defaultValue)
        {
            if (!container.Values.ContainsKey(key))
            {
                return defaultValue;
            }

            return (T)container.Values[key];
        }
    }
}