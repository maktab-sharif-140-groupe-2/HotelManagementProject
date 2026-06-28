using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IRoomRepository : IGenericRepository<Room>
{
    Task<bool> UpdateRoomPriceAsync(Room room,decimal newPrice);

}
