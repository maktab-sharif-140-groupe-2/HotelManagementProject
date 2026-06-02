using HotelManagementProject.Domain.Entites;

namespace HotelMangement_Service.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(Guid roomId,DateTime enteryDate,int daysofStay);

    }
}
