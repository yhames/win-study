using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Kakao.Utils.Extensions;

namespace Kakao.Utils.Attaches;

public class ComboBoxBackgroundProperty
{
    private static Brush? _newBrush;

    public static Brush GetBackground(DependencyObject obj)
    {
        return (Brush)obj.GetValue(BackgroundProperty);
    }

    public static void SetBackground(DependencyObject obj, Brush value)
    {
        obj.SetValue(BackgroundProperty, value);
    }

    public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(ComboBoxBackgroundProperty),
            new UIPropertyMetadata(Brushes.Transparent));

    /**
     * Xaml 파일에 해당 속성을 지정하면 해당 이벤트를 감지하여 자동으로 실행되는 함수
     */
    private static void BackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ComboBox comboBox || e.OldValue == e.NewValue)
        {
            return;
        }

        _newBrush = e.NewValue as Brush;
        
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

        comboBox.SetBackGround(_newBrush ?? Brushes.Transparent);
    }

    private static void ComboBoxUnloaded(object sender, RoutedEventArgs e)
    {
        if (sender is not ComboBox comboBox)
        {
            return;
        }

        comboBox.Loaded -= ComboBoxLoaded;
        comboBox.Unloaded -= ComboBoxUnloaded;
        _newBrush = null;
    }
}