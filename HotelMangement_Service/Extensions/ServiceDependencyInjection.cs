using HotelMangement_Service.Interfaces;
using HotelMangement_Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelMangement_Service.Extensions;

public static class ServiceDependencyInjection
{

    public static IServiceCollection AddServiceDependency(this IServiceCollection services)
    {
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}
