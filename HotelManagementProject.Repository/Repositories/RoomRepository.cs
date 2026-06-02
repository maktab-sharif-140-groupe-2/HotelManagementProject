using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain;
using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProject.Repository.Repositories;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Room?> GetRoomByRoomNumberAsync(int roomNumber, bool tracking = false)
    {
        var query = Entities.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(r =>  r.RoomNumber == roomNumber);
    }
}
