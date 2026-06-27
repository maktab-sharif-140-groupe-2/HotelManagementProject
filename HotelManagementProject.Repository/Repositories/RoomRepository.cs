using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;
namespace HotelManagementProject.Repository.Repositories;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> UpdateRoomPriceAsync(Room room,decimal newPrice)
    {
        room.UpdateInfo(newPrice);
        var entry=Entities.Update(room);
        return entry.State == EntityState.Modified;
        
    }
}
