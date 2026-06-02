using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
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
        ValidateForCreate(roomNumber, pricePerNight, hotelId);

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

    public async Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber, bool tracking = false)
    {
        if (roomNumber < 0)
            throw new InvalidOperationException("invalid roomNumber! the room number input cannot be negative");

        var room = await _roomRepository.GetRoomByRoomNumberAsync(roomNumber, tracking);

        return room is null ? null : new RoomDto
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

    public Task<bool> SodtDeleteAsync(int roomId)
    {
        if (roomId < 0)
            throw new InvalidOperationException("invalid roomId! the room number input cannot be negative");

        return _roomRepository.SoftDeleteAsync(roomId);
    }

    public async Task<bool> UpdatePricePerNightAsync(int roomId, decimal pricePerNight)
    {
        ValidateForUpdate(pricePerNight, roomId);

        var room = await _roomRepository.GetByIdAsync(roomId, true);

        if (room == null)
            return false;

        room.UpdatePricePerNight(pricePerNight);

        return await _roomRepository.UpdateAsync(room);
    }

    private void ValidateForCreate(int roomNumber, decimal pricePerNight, int hotelId)
    {
        if (roomNumber < 0)
            throw new InvalidOperationException("invalid room Number! the room Number cannot be negative");
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid pricePerNight! the pricePerNight cannot be negative");
        if (hotelId < 0)
            throw new InvalidOperationException("invalid hotelId! the hotelId cannot be negative");
    }

    private void ValidateForUpdate(decimal pricePerNight, int hotelId)
    {
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid pricePerNight! the pricePerNight cannot be negative");
        if (hotelId < 0)
            throw new InvalidOperationException("invalid hotelId! the hotelId cannot be negative");
    }
}
