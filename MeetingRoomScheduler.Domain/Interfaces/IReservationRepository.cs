using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Entities.Enums;

namespace MeetingRoomScheduler.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation?> GetReservationById(Guid id);
    Task<IEnumerable<Reservation>> GetReservationByUserId(Guid userId);
    Task<IEnumerable<Reservation>> GetReservationByRoomId(Guid roomId);
    Task<IEnumerable<Reservation>> GetReservationByDate(DateTime date);
    Task<IEnumerable<Reservation>> GetReservationsByFilters(DateTime? date, ReservationStatus? status);

    Task AddReservation(Reservation reservation);
    Task UpdateReservation(Reservation reservation);
    Task DeleteReservation(Guid id);
}
