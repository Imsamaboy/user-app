using vk_testing.Models;

namespace vk_testing.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserById(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
    Task<IEnumerable<User>> GetPagedUsers(int pageNumber, int pageSize);
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(Guid id);
}