using WpfTutorial.Models;

namespace WpfTutorial.Services;

public interface IReservationCreator
{
    Task CreateReservation(Reservation reservation);
}