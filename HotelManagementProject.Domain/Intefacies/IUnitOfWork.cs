using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject.Domain.Intefacies
{
    public interface IUnitOfWork
    {

        public IBookingRepository BookingRepository { get; }

        public IGuestRepository GuestRepository { get; }

        public IHotelRepository HotelRepository { get; }

        public IRoomRepository RoomRepository { get; }

        Task SaveAsync();
    }
}
