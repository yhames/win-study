using Kakao.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kakao.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<MainViewModel>();
        }
    }
}
