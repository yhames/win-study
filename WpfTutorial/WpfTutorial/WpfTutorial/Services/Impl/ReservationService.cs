using Microsoft.EntityFrameworkCore;
using WpfTutorial.DbContexts;
using WpfTutorial.Models;

namespace WpfTutorial.Services.Impl;

public class ReservationService(ReservationDbContextFactory dbContextFactory) : IReservationService
{
    public async Task Save(Reservation reservation)
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDto = reservation.ToDto();
        context.Reservations.Add(reservationDto);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> FindAll()
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDtoList = await context.Reservations.ToListAsync();
        return reservationDtoList.Select(Reservation.FromDto);
    }

    public async Task<Reservation?> FindReservationConflicting(Reservation reservation)
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDto = await context.Reservations
            .Where(dto => dto.FloorNumber == reservation.RoomId.FloorNumber)
            .Where(dto => dto.RoomNumber == reservation.RoomId.RoomNumber)
            .Where(dto => dto.EndDate > reservation.StartDate)
            .Where(dto => dto.StartDate < reservation.EndDate)
            .FirstOrDefaultAsync();
        return reservationDto == null ? null : Reservation.FromDto(reservationDto);
    }
}