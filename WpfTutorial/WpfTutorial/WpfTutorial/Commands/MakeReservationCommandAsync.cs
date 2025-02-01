using System.ComponentModel;
using System.Windows;
using WpfTutorial.Commands.Base;
using WpfTutorial.Exceptions;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.Commands;

public class MakeReservationCommandAsync : AsyncCommandBase
{
    private readonly HotelStore _hotelStore;
    private readonly MakeReservationViewModel _viewModel;
    private readonly NavigationService<ReservationListingViewModel> _navigationService;

    public MakeReservationCommandAsync(MakeReservationViewModel viewModel, HotelStore hotelStore,
        NavigationService<ReservationListingViewModel> navigationService,
        Action<Exception>? onException = null) : base(onException)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;
        _hotelStore = hotelStore;
        _viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnCanExecuteChanged();
    }

    protected override bool CanExecuteAsync(object? parameter)
    {
        return _viewModel.FloorNumber > 0
               && !string.IsNullOrEmpty(_viewModel.Username)
               && _viewModel.StartDate <= _viewModel.EndDate
               && base.CanExecuteAsync(parameter);
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        _viewModel.IsSubmitting = true;
        var roomId = new RoomId(_viewModel.FloorNumber, _viewModel.RoomNumber);
        var reservation = new Reservation(
            roomId,
            _viewModel.Username,
            _viewModel.StartDate,
            _viewModel.EndDate);

        try
        {
            await _hotelStore.MakeReservation(reservation);
            MessageBox.Show("Reservation added successfully", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
        catch (ReservationConflictException)
        {
            _viewModel.SubmitErrorMessage = "This room is already taken on those dates.";
        }
        catch (InvalidReservationTimeRangeException)
        {
            _viewModel.SubmitErrorMessage = "Start date must be before end date.";
        }
        catch (Exception)
        {
            _viewModel.SubmitErrorMessage = "Failed to make reservation.";
        }
        finally
        {
            _viewModel.IsSubmitting = false;
        }
    }
}