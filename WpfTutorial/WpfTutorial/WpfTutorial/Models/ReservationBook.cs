using WpfTutorial.Exceptions;
using WpfTutorial.Services;

namespace WpfTutorial.Models;

public class ReservationBook(IReservationService reservationService)
{
    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await reservationService.FindAll();
    }

    public async Task AddReservation(Reservation incoming)
    {
        var conflictingReservation = await reservationService.FindReservationConflicting(incoming);
        if (conflictingReservation != null)
        {
            throw new ReservationConflictException(conflictingReservation, incoming);
        }

        await reservationService.Save(incoming);
    }
}