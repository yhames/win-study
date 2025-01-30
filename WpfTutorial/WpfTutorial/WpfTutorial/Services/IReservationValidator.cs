using WpfTutorial.Models;

namespace WpfTutorial.Services;

public interface IReservationValidator
{
    Task<Reservation?> GetConflictingReservation(Reservation reservation);
}