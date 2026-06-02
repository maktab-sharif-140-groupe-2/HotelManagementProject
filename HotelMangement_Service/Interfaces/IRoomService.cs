using HotelManagementProject.Domain.Dtos;

namespace HotelMangement_Service.Interfaces;

public interface IRoomService
{
    Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, int hotelId);

    Task<List<RoomDto>> GetRoomsAsync(bool tracking = false);

    Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber, bool tracking = false);

    Task<RoomDto?> GetRoomByIdAsync(int roomId, bool tracking = false);

    Task<bool> SodtDeleteAsync(int roomId);

    Task<bool> UpdatePricePerNightAsync(int roomId, decimal pricePerNight);

}
