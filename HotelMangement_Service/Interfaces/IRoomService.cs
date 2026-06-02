using HotelManagementProject.Domain.Dtos.ServiceView;

namespace HotelMangement_Service.Interfaces;

public interface IRoomService
{
    Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, Guid hotelId);

    //Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber);

    Task<RoomDto?> GetRoomByIdAsync(Guid roomId, bool tracking = false);

    Task<bool> SoftDeleteAsync(Guid roomId);

    Task<bool> UpdatePricePerNightAsync(Guid roomId, decimal pricePerNight);

}
