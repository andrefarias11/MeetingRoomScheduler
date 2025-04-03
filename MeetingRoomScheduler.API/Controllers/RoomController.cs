using MeetingRoomScheduler.Application.Services;
using MeetingRoomScheduler.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeetingRoomScheduler.Util.Language;

namespace MeetingRoomScheduler.API.Controllers;

[Route("api/rooms")]
[ApiController]
[Authorize]
public class RoomController : ControllerBase
{
    private readonly RoomService _roomService;

    public RoomController(RoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRooms();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        var room = await _roomService.GetRoomById(id);
        return room != null ? Ok(room) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddRoom([FromBody] Room room)
    {
        var success = await _roomService.AddRoom(room.Name, room.Capacity);
        return success ? Ok(new { message = RoomMsg.Room_Creation_Success }) : BadRequest(new { message = RoomMsg.Room_Error});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(Guid id, [FromBody] Room room)
    {
        var success = await _roomService.UpdateRoom(id, room.Name, room.Capacity);
        return success ? Ok(new { message = RoomMsg.Room_Update_Success }) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(Guid id)
    {
        var success = await _roomService.DeleteRoom(id);
        return success ? Ok(new { message = RoomMsg.Room_Remove_Success }) : NotFound();
    }
}
