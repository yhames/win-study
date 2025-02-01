using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfTutorial.Configuration;
using WpfTutorial.DbContexts;
using WpfTutorial.Services;
using WpfTutorial.ViewModels;
using WpfTutorial.Views;

namespace WpfTutorial;

public partial class App : Application
{
    private readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureDbContext()
        .ConfigureStores()
        .ConfigureServices()
        .ConfigureModels()
        .ConfigureViewModels()
        .ConfigureViews()
        .Build();

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        var dbContextFactory = _host.Services.GetRequiredService<ReservationDbContextFactory>();
        using (var reservationDbContext = dbContextFactory.CreateDbContext())
        {
            reservationDbContext.Database.Migrate();
        }

        var navigationService = _host.Services.GetRequiredService<NavigationService<ReservationListingViewModel>>();
        navigationService.Navigate();

        MainWindow = _host.Services.GetRequiredService<MainView>();
        MainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();
        base.OnExit(e);
    }
}