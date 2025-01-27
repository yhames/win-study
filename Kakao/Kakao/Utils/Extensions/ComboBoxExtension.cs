using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Kakao.Utils.Extensions;

public static class ComboBoxExtension
{
    public static void SetBackGround(this ComboBox comboBox, Brush brush)
    {
        SetBackGroundOfBorder(comboBox, brush);
        SetBackgroundOfTextBox(comboBox, brush);
    }

    public static void SetBorderBrush(this ComboBox comboBox, Brush brush)
    {
        var border = comboBox.GetBorder();
        if (border == null)
        {
            return;
        }

        border.BorderBrush = brush;
    }

    #region Private Methods

    private static Border? GetBorder(this ComboBox comboBox)
    {
        var toggleButton = (ToggleButton)comboBox.Template.FindName("ToggleButton", comboBox);
        return toggleButton?.Template.FindName("Border", comboBox) as Border;
    }

    private static void SetBackGroundOfBorder(ComboBox comboBox, Brush brush)
    {
        var border = comboBox.GetBorder();
        if (border == null)
        {
            return;
        }

        border.Background = brush;
    }

    private static void SetBackgroundOfTextBox(ComboBox comboBox, Brush brush)
    {
        var textBox = (TextBox)comboBox.Template.FindName("PART_EditableTextBox", comboBox);
        if (textBox?.Parent is not Border parent)
        {
            return;
        }

        parent.Background = brush;
    }

    #endregion Private Methods
}