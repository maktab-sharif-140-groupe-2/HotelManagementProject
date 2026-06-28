using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Errors;
using HotelMangement_Service.Exceptions;
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
            throw new NotFoundException(ApplicationErrors.NotExsitingError("booking"));
        booking.Delete();
        return true;
    }

    public async Task<bool> CreateBooking(Guid roomId, Guid guestId, DateTime enteryDate, int daysofStay)
    {
        var room = await _roomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            throw new NotFoundException(ApplicationErrors.NotExsitingError("Room"));
        }
        await CheckForConflictBooking(roomId, enteryDate, daysofStay);
        var booking = new Booking(roomId, enteryDate, enteryDate.AddDays(daysofStay),guestId);
        return await _bookingRepository.AddAsync(booking);
    }

    private async Task<bool> CheckForConflictBooking(Guid roomId, DateTime enteryDate, int daysofStay)
    {
        //AI :)
        var checkOut = enteryDate.AddDays(daysofStay);
        var hasConflict = await _bookingRepository.AnyAsync(x => x.RoomId == roomId &&
        enteryDate < x.CheckOut &&
            checkOut > x.CheckIn);
        if (hasConflict)
            throw new DouplicateException(ApplicationErrors.HasRecordError("ReserveTime"));
        return true;
    }



}
