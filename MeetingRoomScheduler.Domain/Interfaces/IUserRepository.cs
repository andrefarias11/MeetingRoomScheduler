using MeetingRoomScheduler.Domain.Entities;

namespace MeetingRoomScheduler.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByEmail(string email);
    Task<IEnumerable<User>> GetAllUsers();
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUserById(Guid id);
}
