using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfTutorial.Commands;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<ReservationViewModel> _reservations = [];
    public ObservableCollection<ReservationViewModel> Reservations => _reservations;
    public ICommand LoadReservationsCommand { get; }
    public ICommand MakeReservationCommand { get; }

    private ReservationListingViewModel(Hotel hotel, INavigationService navigationService)
    {
        MakeReservationCommand = new NavigateCommand(navigationService);
        LoadReservationsCommand = new LoadReservationsCommandAsync(hotel, this);
    }

    public static ReservationListingViewModel LoadViewModel(Hotel hotel, INavigationService navigationService)
    {
        var viewModel = new ReservationListingViewModel(hotel, navigationService);
        viewModel.LoadReservationsCommand.Execute(null);
        return viewModel;
    }

    public void UpdateReservations(IEnumerable<Reservation> reservations)
    {
        _reservations.Clear();
        foreach (var reservation in reservations)
        {
            var reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }
    }
}