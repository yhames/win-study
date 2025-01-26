using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Kakao.Utils.Extensions;

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
            BtnClose.Click += BtnClose_Click;
            BtnMaximize.Click += BtnMaximize_Click;
            BtnMinimize.Click += BtnMinimize_Click;
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
