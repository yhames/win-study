using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kakao.Utils.Controls;

public partial class ComboBoxControl : UserControl
{
    public ComboBoxControl()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty IsEditableProperty =
        DependencyProperty.Register(nameof(IsEditable), typeof(bool), typeof(ComboBoxControl),
            new PropertyMetadata(true));

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(ComboBoxControl),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty ValidationProperty =
        DependencyProperty.Register(nameof(Validation), typeof(bool), typeof(ComboBoxControl),
            new PropertyMetadata(false));

    public static readonly DependencyProperty WaterMarkTextProperty =
        DependencyProperty.Register(nameof(WaterMarkText), typeof(string), typeof(ComboBoxControl),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty WaterMarkTextColorProperty =
        DependencyProperty.Register(nameof(WaterMarkTextColor), typeof(Brush), typeof(ComboBoxControl),
            new UIPropertyMetadata(Brushes.Gray));

    public new static readonly DependencyProperty BorderBrushProperty =
        DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(ComboBoxControl),
            new UIPropertyMetadata(Brushes.SkyBlue));

    public new static readonly DependencyProperty BorderThicknessProperty =
        DependencyProperty.Register(nameof(BorderThickness), typeof(Thickness), typeof(ComboBoxControl),
            new UIPropertyMetadata(new Thickness(1)));

    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(ComboBoxControl),
            new PropertyMetadata(null));

    public static readonly DependencyProperty SelectedIndexProperty =
        DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(ComboBoxControl),
            new PropertyMetadata(0));

    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ComboBoxControl),
            new PropertyMetadata(null));

    public static readonly DependencyProperty ItemContainerStyleProperty =
        DependencyProperty.Register(nameof(ItemContainerStyle), typeof(Style), typeof(ComboBoxControl),
            new PropertyMetadata(null));

    public bool IsEditable
    {
        get => (bool)GetValue(IsEditableProperty);
        set => SetValue(IsEditableProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public bool Validation
    {
        get => (bool)GetValue(ValidationProperty);
        set => SetValue(ValidationProperty, value);
    }

    public string WaterMarkText
    {
        get => (string)GetValue(WaterMarkTextProperty);
        set => SetValue(WaterMarkTextProperty, value);
    }

    public Brush WaterMarkTextColor
    {
        get => (Brush)GetValue(WaterMarkTextColorProperty);
        set => SetValue(WaterMarkTextColorProperty, value);
    }

    public new Brush BorderBrush
    {
        get => (Brush)GetValue(BorderBrushProperty);
        set => SetValue(BorderBrushProperty, value);
    }

    public new Thickness BorderThickness
    {
        get => (Thickness)GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }

    public object SelectedItem
    {
        get => (object)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public Style ItemContainerStyle
    {
        get => (Style)GetValue(ItemContainerStyleProperty);
        set => SetValue(ItemContainerStyleProperty, value);
    }
}