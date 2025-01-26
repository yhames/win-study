using System.Globalization;
using System.Windows;
using System.Windows.Data;
using FontAwesome6;

namespace Kakao.Utils.Converters;

internal class WinStateIconConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return EFontAwesomeIcon.Regular_Square;
        }

        return (WindowState)value == WindowState.Maximized
            ? EFontAwesomeIcon.Solid_DownLeftAndUpRightToCenter
            : EFontAwesomeIcon.Regular_Square;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}