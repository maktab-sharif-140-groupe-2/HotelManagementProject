using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IBookingRepository
{
    Task<List<Booking>> GetBookingsAsync();
    Task<Booking?> GetBookingAsync(Guid id);
    Task<bool> AddBookingAsync(Booking booking);
    Task<bool> UpdateBookingAsync(Guid id, BookingUpdateDTO booking);
    Task<bool> DeleteAsync(Guid id);
}
