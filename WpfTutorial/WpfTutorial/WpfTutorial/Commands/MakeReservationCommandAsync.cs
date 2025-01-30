using System.ComponentModel;
using System.Windows;
using WpfTutorial.Commands.Base;
using WpfTutorial.Exceptions;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Commands;

public class MakeReservationCommandAsync : AsyncCommandBase
{
    private readonly MakeReservationViewModel _makeReservationViewModel;
    private readonly Hotel _hotel;
    private readonly INavigationService _navigationService;

    public MakeReservationCommandAsync(MakeReservationViewModel makeReservationViewModel, Hotel hotel,
        INavigationService navigationService, Action<Exception>? onException = null) : base(onException)
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

    protected override bool CanExecuteAsync(object? parameter)
    {
        return _makeReservationViewModel.FloorNumber > 0
               && !string.IsNullOrEmpty(_makeReservationViewModel.Username)
               && _makeReservationViewModel.StartDate <= _makeReservationViewModel.EndDate
               && base.CanExecuteAsync(parameter);
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var roomId = new RoomId(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber);
        var reservation = new Reservation(
            roomId,
            _makeReservationViewModel.Username,
            _makeReservationViewModel.StartDate,
            _makeReservationViewModel.EndDate);

        try
        {
            await _hotel.MakeReservation(reservation);
            MessageBox.Show("Reservation added successfully", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
        catch (ReservationConflictException)
        {
            MessageBox.Show("This room has already reserved.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception)
        {
            MessageBox.Show("Failed to make reservation", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}