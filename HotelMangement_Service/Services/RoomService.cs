using HotelManagementProject.Domain.Dtos.ServiceView;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;
using HotelMangement_Service.Interfaces;

namespace HotelMangement_Service.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IHotelRepository _hotelRepository;

    public RoomService(IRoomRepository roomRepository, IHotelRepository hotelRepository)
    {
        _roomRepository = roomRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, Guid hotelId)
    {
        await ValidateForCreate(roomNumber, pricePerNight, hotelId);

        var room = new Room(roomNumber, pricePerNight, hotelId);

        return await _roomRepository.AddAsync(room);
    }

    public async Task<RoomDto?> GetRoomByIdAsync(Guid roomId, bool tracking)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, tracking);

        return new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        };
    }

    //public async Task<RoomDto?> GetRoomByRoomNumberAsync(int roomNumber)
    //{
    //    var room = await _roomRepository.GetRoomByRoomNumberAsync(roomNumber);

    //    return room is null ? null : new RoomDto
    //    {
    //        HotelId = room.HotelId,
    //        PricePerNight = room.PricePerNight,
    //        RoomNumber = room.RoomNumber,
    //    };
    //}

    public async Task<List<RoomDto>> GetRoomsAsync()
    {
        return await _roomRepository.QueryAsync(room => new RoomDto
        {
            HotelId = room.HotelId,
            PricePerNight = room.PricePerNight,
            RoomNumber = room.RoomNumber,
        }, tracking);
    }

    public async Task<bool> SodtDeleteAsync(Guid roomId)
    {
        var room= await _roomRepository.GetByIdAsync(roomId);
        if (room == null)
            throw new InvalidDataException("this room not exist");
        room.Delete();
        return true;
    }

    public async Task<bool> UpdatePricePerNightAsync(Guid roomId, decimal pricePerNight)
    {
        var room = await _roomRepository.GetByIdAsync(roomId);
        if (room == null)
            throw new InvalidDataException("this room not exist");
        room.UpdatePrice(pricePerNight);
        return true;
    }

    private async Task ValidateForCreate(int roomNumber, decimal pricePerNight, Guid hotelId)
    {
        var hotel= await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel is null)
            throw new InvalidDataException("This hotel not exsit");
        if (roomNumber < 0)
            throw new InvalidOperationException("invalid room Number! the room Number cannot be negative");
        if (pricePerNight < 0)
            throw new InvalidOperationException("invalid room Number! the pricePerNight cannot be negative");
    }
}
