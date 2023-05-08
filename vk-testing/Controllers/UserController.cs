using Microsoft.AspNetCore.Mvc;
using vk_testing.Models;
using vk_testing.Services.Interfaces;

namespace vk_testing.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetAllUsers();
        return new JsonResult(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return new JsonResult(user);
    }

    // TODO: Create UserDto, add mapper
    [HttpPost]
    public IActionResult AddUser([FromBody] UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _userService.CreateUser(user);
        return new JsonResult(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        _userService.DeleteUser(id);
        return new JsonResult(user);
    }

    [HttpGet("paged")]
    public IActionResult GetUsersPaged(int pageNumber = 1, int pageSize = 10)
    {
        var users = _userService.GetPagedUsers(pageNumber, pageSize);
        return new JsonResult(users);
    }
}