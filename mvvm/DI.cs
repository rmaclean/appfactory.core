//-----------------------------------------------------------------------
// <copyright file="DI.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.mvvm
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