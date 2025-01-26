using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kakao.Utils.Converters;

public class WinStateMarginConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return IsBtnClose(value, parameter)
            ? new Thickness(0, 7, (string)parameter! == "BtnClose" ? 7 : 0, 0)
            : new Thickness(0);
    }

    private static bool IsBtnClose(object? value, object? parameter)
    {
        return value != null && parameter != null && (WindowState)value == WindowState.Maximized;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}