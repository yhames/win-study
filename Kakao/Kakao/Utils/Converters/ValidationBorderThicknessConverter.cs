using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kakao.Utils.Converters;

public class ValidationBorderThicknessConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool?)values[0] == false)
        {
            return new Thickness(2);
        }

        return (Thickness)values[1];
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}