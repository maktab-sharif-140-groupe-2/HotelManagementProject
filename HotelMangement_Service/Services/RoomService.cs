using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;
using HotelMangement_Service.Errors;
using HotelMangement_Service.Exceptions;
using HotelMangement_Service.Interfaces;
using MapsterMapper;

namespace HotelMangement_Service.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    private readonly IMapper _mapper;

    public RoomService(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddRoomAsync(int roomNumber, decimal pricePerNight, Guid hotelId)
    {
        var room = new Room(roomNumber, pricePerNight, hotelId);

        return await _roomRepository.AddAsync(room);
    }

    public async Task<RoomDto> GetRoomByIdAsync(Guid roomId, bool tracking = false)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, tracking);
        if (room == null)
            throw new NotFoundException(ApplicationErrors.NotExsitingError("room"));
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

    public async Task<bool> SoftDeleteAsync(Guid roomId)
    {
        var exist=await _roomRepository.AnyAsync(x=> x.Id==roomId);
        if(!exist)
            throw new NotFoundException(ApplicationErrors.NotExsitingError("room"));

        return await _roomRepository.SoftDeleteAsync(roomId);
    }

    public async Task<bool> UpdateRoomAsync(RoomUpdateDTO roomUpdateDTO)
    {
        var room = await _roomRepository.GetByIdAsync(roomUpdateDTO.RoomId, true);

        if (room == null)
            throw new NotFoundException(ApplicationErrors.NotExsitingError("room"));

        return await _roomRepository.UpdateRoomPriceAsync(room,roomUpdateDTO.PricePerNight);
    }

 
}
