using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoadingSpinnerControl;

public class LoadingSpinner : Control
{
    public static readonly DependencyProperty IsLoadingProperty =
        DependencyProperty.Register(nameof(IsLoading), typeof(bool), typeof(LoadingSpinner),
            new PropertyMetadata(false));

    public static readonly DependencyProperty ThicknessProperty =
        DependencyProperty.Register(nameof(Thickness), typeof(double), typeof(LoadingSpinner),
            new PropertyMetadata(1.0));

    public static readonly DependencyProperty DiameterProperty =
        DependencyProperty.Register(nameof(Diameter), typeof(double), typeof(LoadingSpinner),
            new PropertyMetadata(100.0));

    public static readonly DependencyProperty ColorProperty =
        DependencyProperty.Register(nameof(Color), typeof(Brush), typeof(LoadingSpinner),
            new PropertyMetadata(Brushes.Gray));

    public static readonly DependencyProperty CapProperty =
        DependencyProperty.Register(nameof(Cap), typeof(PenLineCap), typeof(LoadingSpinner),
            new PropertyMetadata(PenLineCap.Flat));

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public double Thickness
    {
        get => (double)GetValue(ThicknessProperty);
        set => SetValue(ThicknessProperty, value);
    }

    public double Diameter
    {
        get => (double)GetValue(DiameterProperty);
        set => SetValue(DiameterProperty, value);
    }

    public Brush Color
    {
        get => (Brush)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public PenLineCap Cap
    {
        get => (PenLineCap)GetValue(CapProperty);
        set => SetValue(CapProperty, value);
    }

    static LoadingSpinner()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingSpinner),
            new FrameworkPropertyMetadata(typeof(LoadingSpinner)));
    }
}