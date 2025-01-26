using System.Windows;
using Kakao.Configuration;
using Kakao.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Kakao
{
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        public App()
        {
            Services = AppConfig.ConfigureServices();
            Startup += AppStartUp;
        }

        private void AppStartUp(object sender, StartupEventArgs e)
        {
            MainView? mainView = Current.Services.GetService<MainView>();
            if (mainView == null)
            {
                Shutdown();
                return;
            }

            mainView.Show();
        }
    }
}