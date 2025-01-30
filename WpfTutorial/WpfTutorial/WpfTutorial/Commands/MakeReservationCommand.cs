using System.ComponentModel;
using System.Windows;
using WpfTutorial.Exceptions;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Commands;

public class MakeReservationCommand : CommandBase
{
    private readonly MakeReservationViewModel _makeReservationViewModel;
    private readonly Hotel _hotel;
    private readonly NavigationService _navigationService;

    public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel,
        NavigationService navigationService)
    {
        _makeReservationViewModel = makeReservationViewModel;
        _navigationService = navigationService;
        _hotel = hotel;
        makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnCanExecuteChanged();
    }

    public override bool CanExecute(object? parameter)
    {
        return _makeReservationViewModel.FloorNumber > 0
               && !string.IsNullOrEmpty(_makeReservationViewModel.Username)
               && _makeReservationViewModel.StartDate <= _makeReservationViewModel.EndDate
               && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        var roomId = new RoomId(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber);
        var reservation = new Reservation(
            roomId,
            _makeReservationViewModel.Username,
            _makeReservationViewModel.StartDate,
            _makeReservationViewModel.EndDate);

        try
        {
            _hotel.MakeReservation(reservation);
            MessageBox.Show("Reservation added successfully", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
        catch (ReservationConflictException e)
        {
            MessageBox.Show("This room has already reserved.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}