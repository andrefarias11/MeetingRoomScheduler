using MeetingRoomScheduler.Domain.Entities.Base;
using MeetingRoomScheduler.Domain.Entities.Enums;

namespace MeetingRoomScheduler.Domain.Entities;

public class Reservation : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Active;
}
