

using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;

namespace HotelMangement_Service.Interfaces;

public interface IRoomService
{
    Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, int hotelId);

    Task<List<RoomDto>> GetRoomsAsync(bool tracking = false);

    Task<RoomDto?> GetRoomByIdAsync(int roomId, bool tracking = false);

    Task<bool> SoftDeleteAsync(int roomId);

    Task<bool> UpdateRoomAsync(RoomUpdateDTO roomUpdateDTO);

}
