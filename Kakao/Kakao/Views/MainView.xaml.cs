using System.Windows;
using Kakao.ViewModels;

namespace Kakao.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(MainViewModel));
        }
    }
}
