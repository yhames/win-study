using System.Windows;
using WpfTutorial.Commands.Base;
using WpfTutorial.Models;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Commands;

public class LoadReservationsCommandAsync(
    Hotel hotel,
    ReservationListingViewModel viewModel,
    Action<Exception>? onException = null)
    : AsyncCommandBase(onException)
{
    protected override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            var reservations = await hotel.GetAllReservations();
            viewModel.UpdateReservations(reservations);
        }
        catch (Exception)
        {
            MessageBox.Show("Failed to load reservations", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}