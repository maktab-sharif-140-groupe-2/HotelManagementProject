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

    public async Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, int hotelId)
    {
        var room = new Room(roomNumber, pricePerNight, hotelId);

        return await _roomRepository.AddAsync(room);
    }

    public async Task<RoomDto?> GetRoomByIdAsync(int roomId, bool tracking = false)
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

    public Task<bool> SoftDeleteAsync(int roomId)
    {
        return _roomRepository.SoftDeleteAsync(roomId);
    }

    public async Task<bool> UpdateRoomAsync(RoomUpdateDTO roomUpdateDTO)
    {
        var room = await _roomRepository.GetByIdAsync(roomUpdateDTO.RoomId, true);

        if (room == null)
            return false;

        room.UpdateInfo(roomUpdateDTO.PricePerNight, roomUpdateDTO.HotelId);

        return await _roomRepository.UpdateAsync(room);
    }

   

    private async Task ValidateForCreate(int roomNumber, decimal pricePerNight, Guid hotelId)
    {
        if (roomNumber < 0)
            throw new InvalidOperationException("invalid room Number! the room Number cannot be negative");
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid pricePerNight! the pricePerNight cannot be negative");
        if (hotelId < 0)
            throw new InvalidOperationException("invalid hotelId! the hotelId cannot be negative");
    }

    private void ValidateForUpdate(int roomId, decimal pricePerNight, int hotelId)
    {
        if (roomId < 0)
            throw new InvalidOperationException("invalid roomId! the room Number cannot be negative");
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid pricePerNight! the pricePerNight cannot be negative");
        if (hotelId < 0)
            throw new InvalidOperationException("invalid hotelId! the hotelId cannot be negative");
    }
}
