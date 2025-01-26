using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kakao.Utils.Controls;

public partial class PasswordBoxControl
{
    public PasswordBoxControl()
    {
        InitializeComponent();
    }

    #region Method

    /**
     * FIXME: PasswordBox와 TextBox를 직접적으로 바인딩하는 방식은 보안에 취약할 수 있으므로 권장되지 않는다.
     */
    private void PwdPasswordChanged(object sender, RoutedEventArgs e)
    {
        IsPasswordEmpty = string.IsNullOrEmpty(Pwd.Password);
    }

    #endregion

    #region Public Properties

    public bool Validation
    {
        get => (bool)GetValue(ValidationProperty);
        set => SetValue(ValidationProperty, value);
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

    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    public bool IsPasswordEmpty
    {
        get => (bool)GetValue(IsPasswordEmptyProperty);
        set => SetValue(IsPasswordEmptyProperty, value);
    }

    #endregion

    #region Public Statics

    public static readonly DependencyProperty ValidationProperty =
        DependencyProperty.Register(nameof(Validation), typeof(bool), typeof(PasswordBoxControl),
            new PropertyMetadata(false));

    public new static readonly DependencyProperty BorderBrushProperty =
        DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(PasswordBoxControl),
            new UIPropertyMetadata(Brushes.SkyBlue));

    public new static readonly DependencyProperty BorderThicknessProperty =
        DependencyProperty.Register(nameof(BorderThickness), typeof(Thickness), typeof(PasswordBoxControl),
            new UIPropertyMetadata(new Thickness(1)));

    public static readonly DependencyProperty WaterMarkTextProperty =
        DependencyProperty.Register(nameof(WaterMarkText), typeof(string), typeof(PasswordBoxControl),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty WaterMarkTextColorProperty =
        DependencyProperty.Register(nameof(WaterMarkTextColor), typeof(Brush), typeof(PasswordBoxControl),
            new UIPropertyMetadata(Brushes.Gray));

    /**
     * BindsTwoWayByDefault
     *
     * 양방향 데이터 바인딩을 기본값으로 활성화하는 설정.
     * UI 요소에서 값이 변경되면 데이터 객체도 자동으로 업데이트되고,
     * 반대로 데이터 객체가 변경되면 UI 요소의 값도 자동으로 업데이트 됩니다.
     */
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(nameof(Password), typeof(string), typeof(PasswordBoxControl),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty IsPasswordEmptyProperty =
        DependencyProperty.Register(nameof(IsPasswordEmpty), typeof(bool), typeof(PasswordBoxControl),
            new PropertyMetadata(true));

    #endregion
}