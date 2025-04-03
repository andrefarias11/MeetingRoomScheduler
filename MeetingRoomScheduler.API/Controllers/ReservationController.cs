using MeetingRoomScheduler.Application.Services;
using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Entities.Enums;
using MeetingRoomScheduler.Util.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduler.API.Controllers;

[Route("api/reservations")]
[ApiController]
[Authorize]
public class ReservationController : ControllerBase
{
    private readonly ReservationService _reservationService;

    public ReservationController(ReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetReservationsByUser(Guid userId)
    {
        var reservations = await _reservationService.GetReservationsByUser(userId);
        return Ok(reservations);
    }

    [HttpGet("room/{roomId}")]
    public async Task<IActionResult> GetReservationsByRoom(Guid roomId)
    {
        var reservations = await _reservationService.GetReservationsByRoom(roomId);
        return Ok(reservations);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetReservationsByFilters([FromQuery] DateTime? date, [FromQuery] ReservationStatus? status)
    {
        var reservations = await _reservationService.GetReservationsByFilters(date, status);
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
    {
        var success = await _reservationService.AddReservation(reservation.RoomId, reservation.UserId, reservation.StartTime, reservation.EndTime);
        return success ? Ok(new { message = ReservationMsg.Reservation_Success }) : BadRequest(new { message = ReservationMsg.Reservation_Conflict });
    }

    [HttpPut("{id}/cancel")]
    public async Task<IActionResult> CancelReservation(Guid id)
    {
        var success = await _reservationService.CancelReservation(id);
        return success ? Ok(new { message = ReservationMsg.Reservation_Cancelled }) : NotFound();
    }
}
