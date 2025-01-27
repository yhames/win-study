using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Kakao.Utils.Extensions;

public static class ComboBoxBackgroundExtension
{
    public static void SetBackGround(this ComboBox combo, Brush brush)
    {
        SetToggleButtonBackground(combo, brush);
        SetTextBoxBackground(combo, brush);
    }

    private static void SetToggleButtonBackground(ComboBox combo, Brush brush)
    {
        var toggleButton = (ToggleButton)combo.Template.FindName("ToggleButton", combo);
        if (toggleButton?.Template.FindName("Border", combo) is not Border border)
        {
            return;
        }

        border.Background = brush;
    }

    private static void SetTextBoxBackground(ComboBox combo, Brush brush)
    {
        var textBox = (TextBox)combo.Template.FindName("TextBox", combo);
        if (textBox?.Parent is not Border border)
        {
            return;
        }

        border.Background = brush;
    }
}