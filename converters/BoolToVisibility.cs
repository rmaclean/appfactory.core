﻿//-----------------------------------------------------------------------
// <copyright file="BoolToVisibility.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class BoolToVisibility : IValueConverter
    {
        public bool InvertResult { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = (bool)value;
            if (InvertResult)
            {
                input = !input;
            }

            return input ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}