using HotelManagementProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;
namespace HotelManagementProject.DataAccess.AppDbContextFile;
public class AppDbContext:DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
 


}
