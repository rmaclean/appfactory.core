namespace appfactory.core.converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class NullToVis : IValueConverter
    {
        public bool InvertResult { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var result = value == null;

            if (InvertResult)
            {
                result = !result;
            }

            return result ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}