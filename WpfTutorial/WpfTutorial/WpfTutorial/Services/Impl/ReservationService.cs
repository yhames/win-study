using Microsoft.EntityFrameworkCore;
using WpfTutorial.DbContexts;
using WpfTutorial.Dtos;
using WpfTutorial.Models;

namespace WpfTutorial.Services.Impl;

public class ReservationService(ReservationDbContextFactory dbContextFactory) : IReservationService
{
    public async Task CreateReservation(Reservation reservation)
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDto = ToReservationDto(reservation);
        context.Reservations.Add(reservationDto);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllReservations()
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDtoList = await context.Reservations.ToListAsync();
        return reservationDtoList.Select(ToReservation);
    }

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

    private static ReservationDto ToReservationDto(Reservation reservation)
    {
        return new ReservationDto
        {
            FloorNumber = reservation.RoomId?.FloorNumber ?? 0,
            RoomNumber = reservation.RoomId?.RoomNumber ?? 0,
            Username = reservation.Username,
            StartDate = reservation.StartDate,
            EndDate = reservation.EndDate,
        };
    }
    
    private static Reservation ToReservation(ReservationDto item)
    {
        var roomId = new RoomId(item.FloorNumber, item.RoomNumber);
        return new Reservation(roomId, item.Username, item.StartDate, item.EndDate);
    }
}