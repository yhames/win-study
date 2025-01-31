using System.Windows;
using WpfTutorial.Commands.Base;
using WpfTutorial.Models;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Commands;

public class LoadReservationsCommandAsync(
    HotelStore hotelStore,
    ReservationListingViewModel viewModel,
    Action<Exception>? onException = null)
    : AsyncCommandBase(onException)
{
    protected override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            await hotelStore.Load();
            viewModel.UpdateReservations(hotelStore.Reservations);
        }
        catch (Exception)
        {
            MessageBox.Show("Failed to load reservations", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}