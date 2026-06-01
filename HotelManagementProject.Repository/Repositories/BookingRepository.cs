

using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;

namespace HotelManagementProject.Repository.Repositories;

public class BookingRepository : IBookingRepository
{
    public async Task<bool> AddBooking(Booking booking)
    {
        return true;
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> GetBooking(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> GetBookings()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBooking(Guid id, Booking booking)
    {
        throw new NotImplementedException();
    }
}
