using WpfTutorial.DbContexts;
using WpfTutorial.Dtos;
using WpfTutorial.Models;

namespace WpfTutorial.Services.Impl;

public class DatabaseReservationCreator(ReservationDbContextFactory dbContextFactory) : IReservationCreator
{
    public async Task CreateReservation(Reservation reservation)
    {
        await using var context = dbContextFactory.CreateDbContext();
        var reservationDto = ToReservationDto(reservation);
        context.Reservations.Add(reservationDto);
        await context.SaveChangesAsync();
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
}