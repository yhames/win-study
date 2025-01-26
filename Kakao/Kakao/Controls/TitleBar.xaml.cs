using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Kakao.Utils.Extension;

namespace Kakao.Controls
{
    [ObservableObject]
    public partial class TitleBar : UserControl
    {
        private Window? _parentWindow;
        public Window ParentWindow
        {
            get
            {
                if (_parentWindow == null)
                {
                    _parentWindow = this.FindParent<Window>()!;
                }
                return _parentWindow;
            }
            set { _parentWindow = value; }
        }

        private WindowState _winState;
        public WindowState WinState
        {
            get { return _winState; }
            set { SetProperty(ref _winState, value); }
        }

        public TitleBar()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            btnMaximize.Click += BtnMaximize_Click;
            btnMinimize.Click += BtnMinimize_Click;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WinState = WindowState.Minimized;
            ParentWindow.WindowState = WinState;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WinState = (ParentWindow.WindowState == WindowState.Maximized)
                ? WindowState.Normal : WindowState.Maximized;
            ParentWindow.WindowState = WinState;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.Close();
        }
    }
}
