using WpfTutorial.Models;

namespace WpfTutorial.Services;

public interface IReservationService
{
    Task CreateReservation(Reservation reservation);
    Task<IEnumerable<Reservation>> GetAllReservations();
    Task<Reservation?> GetConflictingReservation(Reservation reservation);
}