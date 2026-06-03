using HotelManagementProject.Domain.Entites;

namespace HotelMangement_Service.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(Guid roomId, Guid guestId, DateTime enteryDate,int daysofStay);

    }
}
