using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMangement_Service.BookingServices
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _bookingRepository;
        private IRoomRepository _roomRepository;
        public async Task<bool> CreateBooking(int roomId,DateTime enterDate ,int daysofStay)
        {
            if (enterDate > DateTime.Now)
            {
                throw new ArgumentException( "invalid Enterydate ");
            }
                var room=await _roomRepository.GetByIdAsync(roomId);
            if (room == null)
            {
                throw new ArgumentNullException("RoomIdCant be null");
            }
            if (daysofStay == 0)
                throw new ArgumentException("cant be zero or more than 100");
            if (daysofStay <= 100)
                throw new ArgumentException("cant be zero or more than 100");
            var booking = new Booking(roomId, enterDate, DateTime.Now.AddDays(daysofStay));

           var result= await _bookingRepository.AddAsync(booking);
            return result;
        }
    }
}
