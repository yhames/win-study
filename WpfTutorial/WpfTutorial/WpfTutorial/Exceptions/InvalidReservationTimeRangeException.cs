using WpfTutorial.Models;

namespace WpfTutorial.Exceptions;

public class InvalidReservationTimeRangeException : Exception
{
    public Reservation Reservation { get; }

    public InvalidReservationTimeRangeException(Reservation reservation)
    {
        Reservation = reservation;
    }
}