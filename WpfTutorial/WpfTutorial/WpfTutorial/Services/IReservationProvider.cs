using WpfTutorial.Models;

namespace WpfTutorial.Services;

public interface IReservationProvider
{
    Task<IEnumerable<Reservation>> GetAllReservations();
}