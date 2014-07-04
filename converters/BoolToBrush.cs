namespace appfactory.core.converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class BoolToBrush : IValueConverter
    {
        public SolidColorBrush FalseBrush { get; set; }

        public SolidColorBrush TrueBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? TrueBrush : FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}