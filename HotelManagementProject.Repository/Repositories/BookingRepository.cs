

using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProject.Repository.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _appContext;
    private readonly DbSet<Booking> _bookings;

    public BookingRepository(AppDbContext appContext)
    {
        _appContext = appContext;
        _bookings = _appContext.Bookings;
    }
 
    public async Task<bool> AddBooking(Booking booking)
    {
        _bookings.Add(booking);
        return await _appContext.SaveChangesAsync() > 0;
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
