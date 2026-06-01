using HotelManagementProject.Domain.Entites;

namespace HotelMangement_Service.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(int roomId,int daysofStay);

    }
}
