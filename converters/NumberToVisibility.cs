namespace appfactory.core.converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class NumberToVisibility : IValueConverter
    {
        public double MinToShow { get; set; }
        public double MaxToShow { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = System.Convert.ToDouble(value);          
            return input >= MinToShow && input < MaxToShow ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}