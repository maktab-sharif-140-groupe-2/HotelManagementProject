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
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HotelManagemetDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
 


}
