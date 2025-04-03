using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Interfaces;

namespace MeetingRoomScheduler.Application.Services;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<IEnumerable<Room>> GetAllRooms() =>
        await _roomRepository.GetAllRoom();

    public async Task<Room?> GetRoomById(Guid id) =>
        await _roomRepository.GetRoomById(id);

    public async Task<bool> AddRoom(string name, int capacity)
    {
        var room = new Room { Name = name, Capacity = capacity };
        await _roomRepository.AddRoom(room);
        return true;
    }

    public async Task<bool> UpdateRoom(Guid id, string name, int capacity)
    {
        var room = await _roomRepository.GetRoomById(id);
        if (room == null) return false;

        room.Name = name;
        room.Capacity = capacity;
        await _roomRepository.UpdateRoom(room);
        return true;
    }

    public async Task<bool> DeleteRoom(Guid id)
    {
        var room = await _roomRepository.GetRoomById(id);
        if (room == null) return false;

        await _roomRepository.DeleteRoom(id);
        return true;
    }
}