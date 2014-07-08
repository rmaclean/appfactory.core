namespace appfactory.core.converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class IntToBrush : IValueConverter
    {
        public Brush EqualsBrush { get; set; }

        public int Match { get; set; }

        public Brush NoEqualBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var result = (int)value == Match;
            return result ? EqualsBrush : NoEqualBrush;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}