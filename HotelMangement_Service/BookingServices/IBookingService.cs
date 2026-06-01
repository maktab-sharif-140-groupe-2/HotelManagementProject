using HotelManagementProject.Domain.Entites;

namespace HotelMangement_Service.BookingServices
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(int roomId,DateTime enterDate,int daysofStay);

    }
}
