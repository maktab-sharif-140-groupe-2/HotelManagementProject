using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IRoomRepository
{
    Task<List<Room>> GetRoomsAsync();
    Task<Room?> GetRoomAsync(Guid id);
    Task<bool> AddRoomAsync(Room Room);
    Task<bool> UpdateRoomAsync(Guid id, RoomUpdateDTO Room);
    Task<bool> DeleteAsync(Guid id);
}
