namespace WpfTutorial.Models;

public class Hotel(string name, ReservationBook reservationBook)
{
    public string Name { get; } = name;

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        return await reservationBook.GetAllReservations();
    }

    public async Task MakeReservation(Reservation reservation)
    {
        await reservationBook.AddReservation(reservation);
    }
}