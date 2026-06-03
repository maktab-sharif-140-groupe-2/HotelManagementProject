
using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;

namespace HotelMangement_Service.Interfaces;

public interface IRoomService
{
    Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, Guid hotelId);

    Task<RoomDto?> GetRoomByIdAsync(Guid roomId, bool tracking = false);

    Task<bool> SoftDeleteAsync(Guid roomId);

    Task<bool> UpdateRoomAsync(RoomUpdateDTO roomUpdateDTO);

    Task<List<RoomDto>> GetRoomsAsync(bool tracking = false);

}
