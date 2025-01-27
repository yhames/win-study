using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Kakao.Utils.Extensions;

public static class ComboBoxExtension
{
    public static void SetBackGround(this ComboBox comboBox, Brush brush)
    {
        SetToggleButtonBackground(comboBox, brush);
        SetTextBoxBackground(comboBox, brush);
    }

    private static void SetToggleButtonBackground(ComboBox comboBox, Brush brush)
    {
        var toggleButton = (ToggleButton)comboBox.Template.FindName("toggleButton", comboBox);
        var templateRoot = toggleButton?.Template.FindName("templateRoot", toggleButton);
        if (templateRoot is not Border border)
        {
            return;
        }

        border.Background = brush;
    }

    private static void SetTextBoxBackground(ComboBox comboBox, Brush brush)
    {
        var textBox = (TextBox)comboBox.Template.FindName("PART_EditableTextBox", comboBox);
        if (textBox?.Parent is not Border border)
        {
            return;
        }

        border.Background = brush;
    }

    public static void SetBorderBrush(this ComboBox comboBox, Brush brush)
    {
        var toggleButton = (ToggleButton)comboBox.Template.FindName("toggleButton", comboBox);
        var templateRoot = toggleButton?.Template.FindName("templateRoot", toggleButton);
        if (templateRoot is not Border border)
        {
            return;
        }

        border.BorderBrush = brush;
    }
}