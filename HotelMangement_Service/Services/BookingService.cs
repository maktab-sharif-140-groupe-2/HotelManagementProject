using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMangement_Service.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _bookingRepository;
        private IRoomRepository _roomRepository;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public async Task<bool> CreateBooking(Guid roomId,DateOnly enteryDate ,int daysofStay)
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
            await CheckForConflictBooking(roomId,enteryDate,daysofStay);
            var booking = new Booking(roomId,enteryDate, enteryDate.AddDays(daysofStay));
            return await _bookingRepository.AddAsync(booking);
        }

        private async Task<bool> CheckForConflictBooking(Guid roomId, DateOnly enteryDate, int daysofStay)
        {
           var room= await _roomRepository.GetByIdAsync(roomId);
            if (room.Bookings.Any(x => x.CheckIn <= enteryDate && x.CheckOut > enteryDate))
                throw new InvalidDataException("this time room is reserved");
            if(room.Bookings.Any(x=> x.CheckIn< enteryDate.AddDays(daysofStay)))
                throw new InvalidDataException("day ofStay can't be Apply(Room reserved)");
            return true;
        }



    }
}
