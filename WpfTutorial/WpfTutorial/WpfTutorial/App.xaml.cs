using System.Windows;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels;

namespace WpfTutorial;

public partial class App : Application
{
    private readonly Hotel _hotel;
    private readonly NavigationStore _navigationStore;

    public App()
    {
        _hotel = new Hotel("SingletonSeam Suites");
        _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
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
        return new ReservationListingViewModel(_hotel,
            new NavigationService(_navigationStore, CreateMakeReservationViewModel));
    }
}