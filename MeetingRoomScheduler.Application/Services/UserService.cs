using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Interfaces;

namespace MeetingRoomScheduler.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserById(Guid id) => 
        await _userRepository.GetUserById(id);
    

    public async Task<List<User>> GetAllUsers() =>  
        (List<User>)await _userRepository.GetAllUsers();

    public async Task<bool> RegisterUser(string name, string email, string password)
    {
        if (await _userRepository.GetUserByEmail(email) != null)
            return false;
        
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User { Name = name, Email = email, PasswordHash = hashedPassword };

        await _userRepository.AddUser(user);
        return true;
    }

    public async Task<bool> UpdateUser(Guid id, string name, string email)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null) 
            return false;

        user.Name = name;
        user.Email = email;

        await _userRepository.UpdateUser(user);
        return true;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null) 
            return false;

        await _userRepository.DeleteUserById(id);
        return true;
    }
}
