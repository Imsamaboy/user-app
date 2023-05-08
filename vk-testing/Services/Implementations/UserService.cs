using vk_testing.Models;
using vk_testing.Repositories.Interfaces;
using vk_testing.Services.Interfaces;

namespace vk_testing.Services.Implementations;

// TODO: Сделать шифрование пароля
public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> GetUserById(Guid id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<IEnumerable<User>> GetPagedUsers(int pageNumber, int pageSize)
    {
        return await _userRepository.GetPagedUsers(pageNumber, pageSize);
    }

    public async Task CreateUser(User user)
    {
        await _userRepository.CreateUser(user);
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.UpdateUser(user);
    }

    public async Task DeleteUser(Guid id)
    {
        await _userRepository.DeleteUser(id);
    }
}