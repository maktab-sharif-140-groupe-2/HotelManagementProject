using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IBookingRepository
{
    Task<List<Booking>> GetBookings();
    Task<Booking> GetBooking(Guid id);
    Task<bool> AddBooking(Booking booking);
    Task<bool> UpdateBooking(Guid id,Booking booking);
    Task<bool> Delete(Guid id);
}
