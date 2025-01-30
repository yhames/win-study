namespace WpfTutorial.Models;

public class Reservation
{
    public RoomId RoomId { get; }
    public string Username { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }

    public TimeSpan Length => EndDate.Subtract(StartDate);


    public Reservation(RoomId roomId, string username, DateTime startDate, DateTime endDate)
    {
        RoomId = roomId;
        Username = username;
        StartDate = startDate;
        EndDate = endDate;
    }

    public bool Conflict(Reservation reservation)
    {
        if (!Equals(reservation.RoomId, RoomId))
        {
            return false;
        }

        return reservation.StartDate < EndDate && reservation.EndDate > StartDate;
    }
}