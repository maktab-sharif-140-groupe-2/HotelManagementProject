using HotelManagementProject.Domain.Entites;
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

    [HttpGet("{roomId:int}")]
    public async Task<ActionResult<RoomDto>> GetRoomByIdAsync([FromRoute] int roomId)
    {
        var room = await _roomService.GetRoomByIdAsync(roomId);

        if (room == null)
            NotFound($"room with this id {roomId} not found!");

        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomAsync([FromBody] CreateRoomDto createRoomDto)
    {
        if (createRoomDto.RoomNumber < 0 || createRoomDto.PricePerNight < 0 || createRoomDto.HotelId < 0)
            return BadRequest("roomId or PricePerNight or HotelId is Invalid! input cannot be negative");

        var result = await _roomService.AddRoomAsync(createRoomDto.RoomNumber, createRoomDto.PricePerNight, createRoomDto.HotelId);

        if (!result)
            return BadRequest();

        return CreatedAtAction(nameof(GetRoomByIdAsync), new { Id = createRoomDto.RoomNumber }, createRoomDto);
    }

    [HttpDelete("{roomId:int}")]
    public async Task<IActionResult> SoftDeleteRoomAsync([FromRoute] int roomId)
    {
        if (roomId < 0)
            BadRequest("invalid roomId! the room number input cannot be negative");

        var result = await _roomService.SoftDeleteAsync(roomId);

        if (!result)
            return NotFound($"room with this roomId {roomId} not found!");

        return NoContent();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateRoomAsync([FromBody] RoomUpdateDTO roomUpdateDTO)
    {
        if (roomUpdateDTO.RoomId < 0 || roomUpdateDTO.PricePerNight < 0 || roomUpdateDTO.HotelId < 0)
            return BadRequest("roomId or PricePerNight or HotelId is Invalid! input cannot be negative");

        var result = await _roomService.UpdateRoomAsync(roomUpdateDTO);

        if(!result)
            return NotFound($"room with this id {roomUpdateDTO.RoomId} not found!");

        return NoContent();
    }
}
