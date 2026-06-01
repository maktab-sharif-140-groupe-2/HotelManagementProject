using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IRoomRepository
{
    Task<List<Room>> GetRooms();
    Task<Room> GetRoom(Guid id);
    Task<bool> AddRoom(Room Room);
    Task<bool> UpdateRoom(Guid id, Room Room);
    Task<bool> Delete(Guid id);
}
