//-----------------------------------------------------------------------
// <copyright file="AdditionConverter.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.converters
{
    using System;
    using System.Globalization;
    using Windows.UI.Xaml.Data;

    public class AdditionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return System.Convert.ToDouble(value, CultureInfo.InvariantCulture) + System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}