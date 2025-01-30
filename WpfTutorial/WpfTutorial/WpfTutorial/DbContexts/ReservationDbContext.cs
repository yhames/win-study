using Microsoft.EntityFrameworkCore;
using WpfTutorial.Dtos;

namespace WpfTutorial.DbContexts;

public class ReservationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ReservationDto> Reservations { get; set; }
}