using WpfTutorial.Exceptions;

namespace WpfTutorial.Models;

public class ReservationBook
{
    private readonly List<Reservation> _reservations;

    public ReservationBook()
    {
        _reservations = new List<Reservation>();
    }

    public IEnumerable<Reservation> GetReservationsByUsername(string username)
    {
        return _reservations.Where(r => r.Username == username);
    }

    public void AddReservation(Reservation incoming)
    {
        var existing = _reservations
            .Where(existing => existing.Conflict(incoming))
            .ToList();
        if (existing.Count > 0)
        {
            throw new ReservationConflictException(existing[0], incoming);
        }

        _reservations.Add(incoming);
    }

    public IEnumerable<Reservation> GetAllReservations()
    {
        return _reservations;
    }
}