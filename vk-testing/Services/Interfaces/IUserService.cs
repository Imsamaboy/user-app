using vk_testing.Dtos;
using vk_testing.Models;

namespace vk_testing.Services.Interfaces;

public interface IUserService
{
    Task<User> GetUserById(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
    Task<IEnumerable<User>> GetPagedUsers(Page page);
    Task<User> CreateUser(CreateUserDto createUserDto);
    Task<User> DeleteUser(Guid id);
}