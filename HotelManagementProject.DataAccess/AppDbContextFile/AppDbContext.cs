using HotelManagementProject.Domain.Abstraction;
using HotelManagementProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
 


}
