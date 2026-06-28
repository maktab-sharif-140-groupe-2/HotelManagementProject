using HotelManagementProject.Domain.Intefacies;
using HotelManagementProject.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementProject.Repository.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
         services.AddScoped<IRoomRepository, RoomRepository>();
         services.AddScoped<IBookingRepository, BookingRepository>();
         services.AddScoped<IHotelRepository, HotelRepository>();
         services.AddScoped<IGuestRepository, GuestRepository>();

        return services;
    }

}
