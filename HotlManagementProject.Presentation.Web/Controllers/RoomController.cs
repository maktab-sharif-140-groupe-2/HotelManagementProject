using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;
using HotelMangement_Service.Interfaces;
using HotlManagementProject.Presentation.Web.ResultPattern;
using Microsoft.AspNetCore.Mvc;

namespace HotlManagementProject.Presentation.Web.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoomDto>>> GetRoomsAsync()
    {
        var rooms = await _roomService.GetRoomsAsync();

        return Ok(Result<List<RoomDto>>.Success(
            rooms
            ));
    }

    [HttpGet("{roomId:Guid}")]
    public async Task<ActionResult<RoomDto>> GetRoomByIdAsync([FromRoute] Guid roomId)
    {
        var room = await _roomService.GetRoomByIdAsync(roomId);

        return Ok(Result<RoomDto>.Success(
            room
        ));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomAsync([FromBody] CreateRoomDto createRoomDto)
    {
        await _roomService.AddRoomAsync(
            createRoomDto.RoomNumber,
            createRoomDto.PricePerNight,
            createRoomDto.HotelId);

        return Ok(Result.Success());
    }

    [HttpDelete("{roomId:Guid}")]
    public async Task<IActionResult> SoftDeleteRoomAsync([FromRoute] Guid roomId)
    {

        await _roomService.SoftDeleteAsync(roomId);

        return Ok(Result.Success());
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateRoomAsync([FromBody] RoomUpdateDTO roomUpdateDTO)
    {

        await _roomService.UpdateRoomAsync(roomUpdateDTO);

        return Ok(Result.Success());
    }
}
