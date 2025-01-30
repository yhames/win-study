using WpfTutorial.Entity;

namespace WpfTutorial.Models;

public class Reservation(RoomId roomId, string username, DateTime startDate, DateTime endDate)
{
    public RoomId RoomId { get; } = roomId;
    public string Username { get; } = username;
    public DateTime StartDate { get; } = startDate;
    public DateTime EndDate { get; } = endDate;

    public TimeSpan Length => EndDate.Subtract(StartDate);

    public ReservationDto ToDto()
    {
        return new ReservationDto
        {
            FloorNumber = RoomId?.FloorNumber ?? 0,
            RoomNumber = RoomId?.RoomNumber ?? 0,
            Username = Username,
            StartDate = StartDate,
            EndDate = EndDate,
        };
    }

    public static Reservation FromDto(ReservationDto dto)
    {
        var roomId = new RoomId(dto.FloorNumber, dto.RoomNumber);
        return new Reservation(roomId, dto.Username, dto.StartDate, dto.EndDate);
    }
}