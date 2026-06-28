using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Intefacies;
using HotelManagementProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject.Repository.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BookingRepository = new BookingRepository(context);
            GuestRepository = new GuestRepository(context);
            HotelRepository = new HotelRepository(context);
            RoomRepository = new RoomRepository(context);
        }

        public IBookingRepository BookingRepository { get; }

        public IGuestRepository GuestRepository { get; }

        public IHotelRepository HotelRepository { get; }

        public IRoomRepository RoomRepository { get; }

        public async Task<bool> SaveAsync()
        {
          return  await _context.SaveChangesAsync()>0;
        }
    }
}
