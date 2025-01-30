using Microsoft.EntityFrameworkCore;
using WpfTutorial.DbContexts;
using WpfTutorial.Dtos;
using WpfTutorial.Models;

namespace WpfTutorial.Services.Impl;

public class DatabaseReservationValidator(ReservationDbContextFactory dbContextFactory) : IReservationValidator
{
    public async Task<Reservation?> GetConflictingReservation(Reservation reservation)
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDto = await context.Reservations
            .Where(dto => dto.FloorNumber == reservation.RoomId.FloorNumber)
            .Where(dto => dto.RoomNumber == reservation.RoomId.RoomNumber)
            .Where(dto => dto.EndDate > reservation.StartDate)
            .Where(dto => dto.StartDate < reservation.EndDate)
            .FirstOrDefaultAsync();
        return reservationDto == null ? null : ToReservation(reservationDto);
    }

    private static Reservation ToReservation(ReservationDto item)
    {
        var roomId = new RoomId(item.FloorNumber, item.RoomNumber);
        return new Reservation(roomId, item.Username, item.StartDate, item.EndDate);
    }
}