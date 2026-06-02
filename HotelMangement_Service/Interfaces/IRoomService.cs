using HotelManagementProject.Domain.Dtos.ServiceView;

namespace HotelMangement_Service.Interfaces;

public interface IRoomService
{
    Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, Guid hotelId);

    Task<List<RoomDto>> GetRoomsAsync();

    //Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber);

    Task<RoomDto?> GetRoomByIdAsync(Guid roomId,bool tracking);

    Task<bool> SodtDeleteAsync(Guid roomId);

    Task<bool> UpdatePricePerNightAsync(Guid roomId, decimal pricePerNight);

}
