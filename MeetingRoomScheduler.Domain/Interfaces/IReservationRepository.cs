using MeetingRoomScheduler.Domain.Entities;

namespace MeetingRoomScheduler.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation?> GetReservationById(Guid id);
    Task<IEnumerable<Reservation>> GetReservationByUserId(Guid userId);
    Task<IEnumerable<Reservation>> GetReservationByRoomId(Guid roomId);
    Task<IEnumerable<Reservation>> GetReservationByDate(DateTime date);
    Task AddReservation(Reservation reservation);
    Task UpdateReservation(Reservation reservation);
    Task DeleteReservation(Guid id);
}
