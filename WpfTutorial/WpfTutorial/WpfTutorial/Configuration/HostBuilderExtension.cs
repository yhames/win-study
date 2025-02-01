using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfTutorial.DbContexts;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Services.Impl;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels;
using WpfTutorial.Views;

namespace WpfTutorial.Configuration;

public static class HostBuilderExtension
{
    public static IHostBuilder ConfigureDbContext(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((hostContext, services) =>
        {
            var connectionString = hostContext.Configuration.GetConnectionString("Default")!;
            services.AddSingleton(new ReservationDbContextFactory(connectionString));
        });
    }

    public static IHostBuilder ConfigureStores(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<HotelStore>();
            services.AddSingleton<NavigationStore>();
        });
    }

    public static IHostBuilder ConfigureModels(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<ReservationBook>();
            services.AddSingleton(CreateHotel);
        });
    }

    public static IHostBuilder ConfigureViewModels(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            /* ReservationListingViewModel */
            services.AddSingleton<Func<ReservationListingViewModel>>(s =>
                s.GetRequiredService<ReservationListingViewModel>);
            services.AddTransient(CreateReservationListingViewModel);

            /* MakeReservationViewModel */
            services.AddSingleton<Func<MakeReservationViewModel>>(s =>
                s.GetRequiredService<MakeReservationViewModel>);
            services.AddTransient<MakeReservationViewModel>();

            /* MainViewModel */
            services.AddSingleton<MainViewModel>();
        });
    }

    public static IHostBuilder ConfigureServices(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<NavigationService<ReservationListingViewModel>>();
            services.AddSingleton<NavigationService<MakeReservationViewModel>>();
            services.AddSingleton<IReservationService, ReservationService>();
        });
    }

    public static IHostBuilder ConfigureViews(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton(s => new MainView
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        });
    }

    #region PrivateMethods

    private static Hotel CreateHotel(IServiceProvider services)
    {
        var reservationBook = services.GetRequiredService<ReservationBook>();
        return new Hotel("SingletonSeam Suites", reservationBook);
    }

    private static ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider services)
    {
        var hostStore = services.GetRequiredService<HotelStore>();
        var navigationService = services.GetRequiredService<NavigationService<MakeReservationViewModel>>();
        return ReservationListingViewModel.LoadViewModel(hostStore, navigationService);
    }

    #endregion PrivateMethods
}