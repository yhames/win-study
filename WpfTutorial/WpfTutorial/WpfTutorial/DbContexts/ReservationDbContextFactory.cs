using Microsoft.EntityFrameworkCore;

namespace WpfTutorial.DbContexts;

public class ReservationDbContextFactory(string connectionString)
{
    public ReservationDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;
        return new ReservationDbContext(options);
    }   
}