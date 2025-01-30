using WpfTutorial.Models;

namespace WpfTutorial.Services;

public interface IReservationService
{
    Task Save(Reservation reservation);
    Task<IEnumerable<Reservation>> FindAll();
    Task<Reservation?> FindReservationConflicting(Reservation reservation);
}