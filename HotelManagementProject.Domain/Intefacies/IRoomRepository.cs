using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IRoomRepository : IGenericRepository<Room>
{
    Task<Room?> GetRoomByRoomNumberAsync(int roomNumber, bool tracking = false);
}
