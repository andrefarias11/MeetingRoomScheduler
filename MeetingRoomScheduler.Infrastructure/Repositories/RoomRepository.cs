using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Interfaces;
using MeetingRoomScheduler.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduler.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room?> GetRoomById(Guid id) =>
            await _context.Room.FindAsync(id);

        public async Task<IEnumerable<Room>> GetAllRoom() =>
            await _context.Room.ToListAsync();

        public async Task AddRoom(Room room)
        {
            await _context.Room.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(Guid id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
