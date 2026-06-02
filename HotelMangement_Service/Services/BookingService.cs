using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Interfaces;
namespace HotelMangement_Service.Services;
public class BookingService : IBookingService
{
    private IBookingRepository _bookingRepository;
    private IRoomRepository _roomRepository;

    public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }

    public async Task<bool> CancelBooking(Guid bookingId)
    {
        var booking=await _bookingRepository.GetByIdAsync(bookingId);
        if (booking == null)
            throw new InvalidDataException("the booking id is invalid");
        booking.Delete();
        return true;
    }

    public async Task<bool> CreateBooking(Guid roomId, DateTime enteryDate, int daysofStay)
    {
        var room = await _roomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            throw new ArgumentNullException("Not Exist this Room");
        }
        if (daysofStay == 0)
            throw new ArgumentException("days of stay can't be zero");
        if (daysofStay > 100)
            throw new ArgumentException("days of stay can't be more than 100");
        await CheckForConflictBooking(roomId, enteryDate, daysofStay);
        var booking = new Booking(roomId, enteryDate, enteryDate.AddDays(daysofStay));
        return await _bookingRepository.AddAsync(booking);
    }

    private async Task<bool> CheckForConflictBooking(Guid roomId, DateOnly enteryDate, int daysofStay)
    {
        //AI :)
        var checkOut = enteryDate.AddDays(daysofStay);
        var hasConflict = await _bookingRepository.AnyAsync(x => x.RoomId == roomId &&
        enteryDate < x.CheckOut &&
            checkOut > x.CheckIn);
        if (hasConflict)
            throw new InvalidDataException("this time room is reserved");
        return true;
    }



}
