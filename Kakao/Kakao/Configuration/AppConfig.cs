using Kakao.ViewModels;
using Kakao.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Kakao.Configuration;

public static class AppConfig
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // ViewModel
        services.AddTransient<MainViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<SignUpViewModel>();
        services.AddTransient<ChangePasswordViewModel>();

        // View
        services.AddSingleton<MainView>();

        return services.BuildServiceProvider();
    }
}