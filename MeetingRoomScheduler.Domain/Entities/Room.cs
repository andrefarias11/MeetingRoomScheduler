using MeetingRoomScheduler.Domain.Entities.Base;

namespace MeetingRoomScheduler.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
}
