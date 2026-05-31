

using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Dtos;
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
 
    public async Task<bool> AddBookingAsync(Booking booking)
    {
        _bookings.Add(booking);
        return await _appContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var booking = await GetBookingAsync(id);
        if (booking is null)
            return false;
        _bookings.Remove(booking);
        return await _appContext.SaveChangesAsync() > 0;
    }


    public async Task<Booking?> GetBookingAsync(Guid id)
    {
       var booking=  _bookings.FirstOrDefaultAsync(b=> b.Id==id);
        return await booking;
    }

    public async Task<List<Booking>> GetBookingsAsync()
    {
      return await _bookings.ToListAsync();
        
    }

    public async Task<bool> UpdateBookingAsync(Guid id, BookingUpdateDTO newbooking)
    {
        var booking = await GetBookingAsync(id);
        if (booking is null)
            return false;
        booking.CheckIn = newbooking.NewCheckIn;
        booking.CheckOut= newbooking.NewCheckOut;
        _bookings.Update(booking);
        return await _appContext.SaveChangesAsync() > 0;

    }
}
