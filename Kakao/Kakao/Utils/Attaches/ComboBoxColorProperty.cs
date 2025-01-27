using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Kakao.Utils.Extensions;

namespace Kakao.Utils.Attaches;

public class ComboBoxColorProperty
{
    # region Fields

    private static Brush? _newBackground;
    private static Brush? _newBorderBrush;

    #endregion Fields

    # region Properties

    public static Brush GetBackground(DependencyObject obj) => (Brush)obj.GetValue(BackgroundProperty);
    public static void SetBackground(DependencyObject obj, Brush value) => obj.SetValue(BackgroundProperty, value);
    public static Brush GetBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(BorderBrushProperty);
    public static void SetBorderBrush(DependencyObject obj, Brush value) => obj.SetValue(BorderBrushProperty, value);

    public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(ComboBoxColorProperty),
            new UIPropertyMetadata(null, BackgroundChanged));

    public static readonly DependencyProperty BorderBrushProperty =
        DependencyProperty.RegisterAttached("BorderBrush", typeof(Brush), typeof(ComboBoxColorProperty),
            new UIPropertyMetadata(null, BorderBrushChanged));

    # endregion Properties

    # region Events

    private static void BackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        AddEvents(d, e, brush => _newBackground = brush);
    }

    private static void BorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        AddEvents(d, e, brush => _newBorderBrush = brush);
    }

    private static void AddEvents(DependencyObject d, DependencyPropertyChangedEventArgs e, Action<Brush> brushCallback)
    {
        if (d is not ComboBox comboBox || e.NewValue is not Brush brush)
        {
            return;
        }

        if (e.OldValue == e.NewValue)
        {
            return;
        }

        brushCallback.Invoke(brush);

        comboBox.Loaded -= ComboBoxLoaded;
        comboBox.Unloaded -= ComboBoxUnloaded;

        comboBox.Loaded += ComboBoxLoaded;
        comboBox.Unloaded += ComboBoxUnloaded;
    }

    private static void ComboBoxLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is not ComboBox comboBox)
        {
            return;
        }

        if (_newBackground != null)
        {
            comboBox.SetBackGround(_newBackground);
        }

        if (_newBorderBrush != null)
        {
            comboBox.SetBorderBrush(_newBorderBrush);
        }
    }

    private static void ComboBoxUnloaded(object sender, RoutedEventArgs e)
    {
        if (sender is not ComboBox comboBox)
        {
            return;
        }

        comboBox.Loaded -= ComboBoxLoaded;
        comboBox.Unloaded -= ComboBoxUnloaded;
        _newBackground = null;
        _newBorderBrush = null;
    }

    # endregion Events
}