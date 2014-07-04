namespace appfactory.core
{
    using System;
    using System.Collections.Generic;

    public static class DI
    {
        private static Dictionary<Type, object> implementations = new Dictionary<Type, object>();

        public static void Add(Type type, object implementation)
        {
            implementations.Add(type, implementation);
        }

        public static T Get<T>()
        {
            return (T)implementations[typeof(T)];
        }
    }
}