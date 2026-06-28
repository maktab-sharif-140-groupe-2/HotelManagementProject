using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Intefacies;
using HotelManagementProject.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementProject.Repository.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options
        .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRoomRepository, RoomRepository>();
         services.AddScoped<IBookingRepository, BookingRepository>();
         services.AddScoped<IHotelRepository, HotelRepository>();
         services.AddScoped<IGuestRepository, GuestRepository>();

        return services;
    }

}
