using MeetingRoomScheduler.Domain.Entities;

namespace MeetingRoomScheduler.Domain.Interfaces;

public interface IRoomRepository
{
    Task<Room?> GetRoomById(Guid id);
    Task<IEnumerable<Room>> GetAllRoom();
    Task AddRoom(Room room);
    Task UpdateRoom(Room room);
    Task DeleteRoom(Guid id);
}
