using WpfTutorial.Commands.Base;
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
        viewModel.ErrorMessage = string.Empty;
        viewModel.IsLoading = true;
        try
        {
            await hotelStore.Load();
            viewModel.UpdateReservations(hotelStore.Reservations);
        }
        catch (Exception)
        {
            viewModel.ErrorMessage = "Failed to load reservations.";
        }
        finally
        {
            viewModel.IsLoading = false;
        }
    }
}