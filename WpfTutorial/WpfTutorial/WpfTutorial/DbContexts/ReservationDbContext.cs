using Microsoft.EntityFrameworkCore;
using WpfTutorial.Entity;

namespace WpfTutorial.DbContexts;

public class ReservationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ReservationDto> Reservations { get; set; }
}