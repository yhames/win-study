using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WpfTutorial.DbContexts;

public class ReservationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
{
    public ReservationDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder().UseSqlite("Data Source=reservation.db").Options;
        return new ReservationDbContext(options);
    }
}