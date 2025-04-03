using MeetingRoomScheduler.Application.Services;
using MeetingRoomScheduler.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduler.API.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserById(id);
        return user != null ? Ok(user) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        var result = await _userService.RegisterUser(user.Name, user.Email, user.PasswordHash);
        return result ? Ok(new { message = "Usuário cadastrado com sucesso!" }) : BadRequest(new { message = "Email já cadastrado." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
    {
        var result = await _userService.UpdateUser(id, user.Name, user.Email);
        return result ? Ok(new { message = "Usuário atualizado com sucesso!" }) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await _userService.DeleteUser(id);
        return result ? Ok(new { message = "Usuário removido com sucesso!" }) : NotFound();
    }
}
