//-----------------------------------------------------------------------
// <copyright file="ApplicationDataContainerExtensions.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.extensions
{
    using System;
    using Windows.Storage;

    public static class ApplicationDataContainerExtensions
    {
        public static T Read<T>(this ApplicationDataContainer container, string key, T defaultValue)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            if (!container.Values.ContainsKey(key))
            {
                return defaultValue;
            }

            return (T)container.Values[key];
        }
    }
}