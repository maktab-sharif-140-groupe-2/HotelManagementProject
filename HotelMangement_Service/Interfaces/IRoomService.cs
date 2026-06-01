using HotelManagementProject.Domain.Dtos;

namespace HotelMangement_Service.Interfaces;

public interface IRoomService
{
    Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, int hotelId);

    Task<List<RoomDto>> GetRoomsAsync();

    Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber);

    Task<RoomDto?> GetRoomByIdAsync(int roomId);

    Task<bool> SodtDeleteAsync(int roomId);

    Task<bool> UpdatePricePerNightAsync(decimal pricePerNight);

}
