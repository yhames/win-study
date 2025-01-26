using Kakao.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Kakao.Configuration
{
    public class AppConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Service

            // View
            services.AddSingleton<MainView>();

            return services.BuildServiceProvider();
        }
    }
}
