using WpfTutorial.DbContexts;
using WpfTutorial.Exceptions;
using WpfTutorial.Services;

namespace WpfTutorial.Models;

public class ReservationBook(
    IReservationProvider reservationProvider,
    IReservationCreator reservationCreator,
    IReservationValidator reservationValidator)
{
    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await reservationProvider.GetAllReservations();
    }

    public async Task AddReservation(Reservation incoming)
    {
        var conflictingReservation = await reservationValidator.GetConflictingReservation(incoming);
        if (conflictingReservation != null)
        {
            throw new ReservationConflictException(conflictingReservation, incoming);
        }

        await reservationCreator.CreateReservation(incoming);
    }
}