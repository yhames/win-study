using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfTutorial.Commands;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Stores;

namespace WpfTutorial.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly Hotel _hotel;

    private readonly ObservableCollection<ReservationViewModel> _reservations = [];
    
    public ObservableCollection<ReservationViewModel> Reservations => _reservations;

    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel(Hotel hotel, NavigationService navigationService)
    {
        _hotel = hotel;
        MakeReservationCommand = new NavigateCommand(navigationService);
        UpdateReservations();
    }

    private void UpdateReservations()
    {
        _reservations.Clear();
        foreach (var reservation in _hotel.GetAllReservations())
        {
            var reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }
    }
}