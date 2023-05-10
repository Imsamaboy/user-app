using vk_testing.Dtos;
using vk_testing.Models;

namespace vk_testing.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserById(Guid id);
    Task<IEnumerable<UserDto>> GetAllUsers();
    Task<IEnumerable<UserDto>> GetPagedUsers(Page page);
    Task<UserDto> CreateUser(CreateUserDto createUserDto);
    Task<UserDto> DeleteUser(Guid id);
}