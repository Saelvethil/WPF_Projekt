using System;
using System.Windows.Data;
using System.Windows.Media;
using TasksLogic;

namespace WPF_PROJEKT
{
    [ValueConversion(typeof(SubtaskPriorities), typeof(SolidColorBrush))]
    public class ColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SubtaskPriorities priority = (SubtaskPriorities)value;
            SolidColorBrush brush;
            switch (priority)
            {
                case SubtaskPriorities.Low:
                    brush = Brushes.GreenYellow;
                    break;
                case SubtaskPriorities.Normal:
                    brush = Brushes.YellowGreen;
                    break;
                case SubtaskPriorities.High:
                    brush = Brushes.Green;
                    break;
                case SubtaskPriorities.VeryHigh:
                    brush = Brushes.DarkGreen;
                    break;
                default:
                    brush = Brushes.YellowGreen;
                    break;
            }
            
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
