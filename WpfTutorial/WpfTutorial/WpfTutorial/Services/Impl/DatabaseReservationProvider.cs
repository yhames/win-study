using Microsoft.EntityFrameworkCore;
using WpfTutorial.DbContexts;
using WpfTutorial.Dtos;
using WpfTutorial.Models;

namespace WpfTutorial.Services.Impl;

public class DatabaseReservationProvider(ReservationDbContextFactory dbContextFactory) : IReservationProvider
{
    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDtoList = await context.Reservations.ToListAsync();
        return reservationDtoList.Select(ToReservation);
    }

    private static Reservation ToReservation(ReservationDto item)
    {
        var roomId = new RoomId(item.FloorNumber, item.RoomNumber);
        return new Reservation(roomId, item.Username, item.StartDate, item.EndDate);
    }
}