using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Interfaces;
using MeetingRoomScheduler.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduler.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers() =>
        await _context.Users.ToListAsync();
    

    public async Task<User?> GetUserByEmail(string email) => 
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    
    public async Task<User?> GetUserById(Guid id) => 
        await _context.Users.FindAsync(id);
    
    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    public async Task AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
