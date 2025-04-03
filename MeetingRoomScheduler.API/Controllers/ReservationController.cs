using MeetingRoomScheduler.Application.Services;
using MeetingRoomScheduler.Domain.Entities;
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

    [HttpPost]
    public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
    {
        var success = await _reservationService.AddReservation(reservation.RoomId, reservation.UserId, reservation.StartTime, reservation.EndTime);
        return success ? Ok(new { message = "Reserva criada com sucesso!" }) : BadRequest(new { message = "Conflito de horário ou dados inválidos." });
    }

    [HttpPut("{id}/cancel")]
    public async Task<IActionResult> CancelReservation(Guid id)
    {
        var success = await _reservationService.CancelReservation(id);
        return success ? Ok(new { message = "Reserva cancelada com sucesso!" }) : NotFound();
    }
}
