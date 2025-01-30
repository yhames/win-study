using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WpfTutorial.DbContexts;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Services.Impl;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels;
using WpfTutorial.Views;

namespace WpfTutorial;

public partial class App : Application
{
    private const string ConnectionString = "Data Source=reservation.db";
    private readonly Hotel _hotel;
    private readonly NavigationStore _navigationStore;
    private readonly ReservationDbContextFactory _reservationDbContextFactory;

    public App()
    {
        _reservationDbContextFactory = new ReservationDbContextFactory(ConnectionString);
        var databaseReservationCreator = new DatabaseReservationCreator(_reservationDbContextFactory);
        var databaseReservationProvider = new DatabaseReservationProvider(_reservationDbContextFactory);
        var databaseReservationViValidator = new DatabaseReservationValidator(_reservationDbContextFactory);

        var reservationBook = new ReservationBook(
            databaseReservationProvider, databaseReservationCreator, databaseReservationViValidator);
        _hotel = new Hotel("SingletonSeam Suites", reservationBook);
        _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using (var reservationDbContext = _reservationDbContextFactory.CreateDbContext())
        {
            reservationDbContext.Database.Migrate();
        }

        _navigationStore.CurrentViewModel = CreateReservationListingViewModel();
        MainWindow = new MainView()
        {
            DataContext = new MainViewModel(_navigationStore)
        };
        MainWindow.Show();
        base.OnStartup(e);
    }

    private MakeReservationViewModel CreateMakeReservationViewModel()
    {
        return new MakeReservationViewModel(_hotel,
            new NavigationService(_navigationStore, CreateReservationListingViewModel));
    }

    private ReservationListingViewModel CreateReservationListingViewModel()
    {
        return ReservationListingViewModel.LoadViewModel(
            _hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
    }
}