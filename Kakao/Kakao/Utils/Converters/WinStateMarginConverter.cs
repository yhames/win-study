using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kakao.Utils.Converters
{
    public class WinStateMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState state = (WindowState)value;
            if (state == WindowState.Maximized)
            {
                return new Thickness(0, 7, (string)parameter == "btnClose" ? 7 : 0, 0);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
