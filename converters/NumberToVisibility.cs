//-----------------------------------------------------------------------
// <copyright file="NumberToVisibility.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.converters
{
    using System;
    using System.Globalization;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class NumberToVisibility : IValueConverter
    {
        public double MaxToShow { get; set; }

        public double MinToShow { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = System.Convert.ToDouble(value, CultureInfo.InvariantCulture);
            return input >= MinToShow && input < MaxToShow ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}