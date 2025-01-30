using WpfTutorial.Exceptions;

namespace WpfTutorial.Models;

public class Hotel
{
    private readonly ReservationBook _reservationBook;

    public string Name { get; }

    public Hotel(string name)
    {
        Name = name;
        _reservationBook = new ReservationBook();
    }

    public IEnumerable<Reservation> GetReservationsByUsername(string username)
    {
        return _reservationBook.GetReservationsByUsername(username);
    }
    
    public IEnumerable<Reservation> GetAllReservations()
    {
        return _reservationBook.GetAllReservations();
    }

    public void MakeReservation(Reservation reservation)
    {
        _reservationBook.AddReservation(reservation);
    }
}