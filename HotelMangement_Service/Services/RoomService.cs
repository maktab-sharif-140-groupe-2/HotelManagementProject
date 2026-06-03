using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;
using HotelMangement_Service.Interfaces;

namespace HotelMangement_Service.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, Guid hotelId)
    {
        ValidatePrice( pricePerNight);
        var room = new Room(roomNumber, pricePerNight, hotelId);

        return await _roomRepository.AddAsync(room);
    }

    public async Task<RoomDto?> GetRoomByIdAsync(Guid roomId, bool tracking = false)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, tracking);

        return new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        };
    }

    public async Task<List<RoomDto>> GetRoomsAsync(bool tracking = false)
    {
        return await _roomRepository.QueryAsync(room => new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        }, tracking);
    }

    public Task<bool> SoftDeleteAsync(Guid roomId)
    {
        return _roomRepository.SoftDeleteAsync(roomId);
    }

    public async Task<bool> UpdateRoomAsync(RoomUpdateDTO roomUpdateDTO)
    {
        var room = await _roomRepository.GetByIdAsync(roomUpdateDTO.RoomId, true);

        if (room == null)
            return false;

        ValidatePrice(roomUpdateDTO.PricePerNight);
        room.UpdateInfo(roomUpdateDTO.PricePerNight);

        return await _roomRepository.UpdateAsync(room);
    }

    private void ValidatePrice(decimal pricePerNight)
    {
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid pricePerNight! the pricePerNight cannot be negative");
    }
}
