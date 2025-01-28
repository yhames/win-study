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

        private static void AppStartUp(object sender, StartupEventArgs e)
        {
            // 생성자에서 실행하면 모든 애플리케이션 리소스가 완전히 로드되지 않은 상태로 실행될 수 있습니다.
            // Application의 Startup 이라는 이벤트에 등록하면 모든 초기화가 정상적으로 로드된 이후 실행하므로
            // 안전하게 Window를 실행할 수 있습니다.
            var mainView = Current.Services.GetRequiredService<MainView>();
            mainView.Show();
        }
    }
}