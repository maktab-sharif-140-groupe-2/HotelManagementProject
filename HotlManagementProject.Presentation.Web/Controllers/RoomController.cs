using HotelMangement_Service.Dto.Request.RoomEntity;
using HotelMangement_Service.Dto.Response.RoomEntity;
using HotelMangement_Service.Interfaces;
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
    public async Task<ActionResult<List<RoomDto>>> GetRoomsAsync() => Ok(await _roomService.GetRoomsAsync());

    [HttpGet("{roomId:Guid}")]
    public async Task<ActionResult<RoomDto>> GetRoomByIdAsync([FromRoute] Guid roomId)
    {
        var room = await _roomService.GetRoomByIdAsync(roomId);

        if (room == null)
            NotFound($"room with this id {roomId} not found!");

        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomAsync([FromBody] CreateRoomDto createRoomDto)
    {
        var result = await _roomService.AddRoomAsync(createRoomDto.RoomNumber, createRoomDto.PricePerNight, createRoomDto.HotelId);

        if (!result)
            return BadRequest();

        return CreatedAtAction(nameof(GetRoomByIdAsync), new { Id = createRoomDto.RoomNumber }, createRoomDto);
    }

    [HttpDelete("{roomId:Guid}")]
    public async Task<IActionResult> SoftDeleteRoomAsync([FromRoute] Guid roomId)
    {

        var result = await _roomService.SoftDeleteAsync(roomId);

        if (!result)
            return NotFound($"room with this roomId {roomId} not found!");

        return NoContent();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateRoomAsync([FromBody] RoomUpdateDTO roomUpdateDTO)
    {

        var result = await _roomService.UpdateRoomAsync(roomUpdateDTO);

        if(!result)
            return NotFound($"room with this id {roomUpdateDTO.RoomId} not found!");

        return NoContent();
    }
}
