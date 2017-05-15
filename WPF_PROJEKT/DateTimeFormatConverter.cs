using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_PROJEKT
{
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value == DateTime.MinValue)
                return string.Empty;
            else
                return String.Format("{0:dddd dd/MM/yyyy}", (DateTime)value);
        }


        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
