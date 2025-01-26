using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Kakao.Utils.Converters;

public class ValidationBorderBrushConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool?)values[0] == false)
        {
            return Brushes.Red;
        }
        return (Brush)values[1];
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}