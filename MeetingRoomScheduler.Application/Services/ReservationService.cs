using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Entities.Enums;
using MeetingRoomScheduler.Domain.Interfaces;

namespace MeetingRoomScheduler.Application.Services;

public class ReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;

    public ReservationService(
        IReservationRepository reservationRepository,
        IRoomRepository roomRepository,
        IUserRepository userRepository)
    {
        _reservationRepository = reservationRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByUser(Guid userId) =>
        await _reservationRepository.GetReservationByUserId(userId);

    public async Task<IEnumerable<Reservation>> GetReservationsByRoom(Guid roomId) =>
        await _reservationRepository.GetReservationByRoomId(roomId);

    public async Task<Reservation?> GetReservationById(Guid id) =>
        await _reservationRepository.GetReservationById(id);

    public async Task<bool> AddReservation(Guid roomId, Guid userId, DateTime startTime, DateTime endTime)
    {
        if (startTime >= endTime)
            return false;

        var room = await _roomRepository.GetRoomById(roomId);
        var user = await _userRepository.GetUserById(userId);
        if (room == null || user == null)
            return false;

        var existingReservations = await _reservationRepository.GetReservationByRoomId(roomId);
        if (existingReservations.Any(r => startTime < r.EndTime && endTime > r.StartTime))
            return false;

        var reservation = new Reservation
        {
            RoomId = roomId,
            UserId = userId,
            StartTime = startTime,
            EndTime = endTime,
            Status = ReservationStatus.Active
        };

        await _reservationRepository.AddReservation(reservation);
        return true;
    }

    public async Task<bool> CancelReservation(Guid id)
    {
        var reservation = await _reservationRepository.GetReservationById(id);
        if (reservation == null) 
            return false;

        reservation.Status = ReservationStatus.Cancelled;
        await _reservationRepository.UpdateReservation(reservation);
        return true;
    }
}
