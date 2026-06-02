using HotelManagementProject.Domain.Entites;

namespace HotelMangement_Service.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(Guid roomId, DateOnly enteryDate,int daysofStay);
        Task<bool> CancelBooking(Guid bookingId);

    }
}
