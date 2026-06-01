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

    public async Task<RoomDto?> GetRoomByIdAsync(int roomId, bool tracking)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, tracking);

        return new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        };
    }

    public async Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber)
    {
        var room = await _roomRepository.GetRoomByRoomNumberAsync(roomNumber);

        return room is null ? null : new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        };
    }

    public async Task<List<RoomDto>> GetRoomsAsync()
    {
        return await _roomRepository.QueryAsync(room => new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        });
    }

    public Task<bool> SodtDeleteAsync(int roomId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdatePricePerNightAsync(decimal pricePerNight)
    {
        throw new NotImplementedException();
    }

    private void ValidateForCreate(int roomNumber, decimal pricePerNight, int hotelId)
    {
        if (roomNumber < 0)
            throw new InvalidOperationException("invalid room Number! the room Number cannot be negative");
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid room Number! the pricePerNight cannot be negative");
        if (hotelId < 0)
            throw new InvalidOperationException("invalid room Number! the hotelId cannot be negative");
    }
}
