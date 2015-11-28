namespace PersonManagementTool.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value == null;

            if (this.IsInverted)
            {
                result = !result;
            }

            return result ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool IsInverted { get; set; }
    }
}