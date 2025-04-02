using MeetingRoomScheduler.Domain.Entities.Base;
using MeetingRoomScheduler.Domain.Entities.Enums;

namespace MeetingRoomScheduler.Domain.Entities;

public class Reservation : BaseEntity
{
    public User? User { get; set; }
    public Room? Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Active;
}
