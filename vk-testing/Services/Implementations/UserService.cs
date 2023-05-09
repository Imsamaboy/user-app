using System.Collections.Concurrent;
using vk_testing.Dtos;
using vk_testing.Exceptions;
using vk_testing.Models;
using vk_testing.Repositories.Interfaces;
using vk_testing.Services.Interfaces;

namespace vk_testing.Services.Implementations;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ConcurrentDictionary<string, bool> _reserved = new();
    private const int Delay = 5000;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    private DateTime GetCurrentTime() => DateTime.Now;

    private void ReserveLogin(string login)
    {
        var isAdded = _reserved.TryAdd(login, default);
        if (!isAdded)
            throw new InvalidOperationException($"Login {login} was reserved by other users");
    }

    private void Cancel(string login)
    {
        var isSuccessfullyRemoved = _reserved.TryRemove(login, out _);
        if (!isSuccessfullyRemoved)
            throw new InvalidOperationException($"No reserved login {login}");
    }

    private bool IsLoginReservedByOtherUser(string login)
    {
        return _reserved.ContainsKey(login);
    }

    public async Task<User> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user is null)
            throw new UserNotFoundException(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<IEnumerable<User>> GetPagedUsers(Page page)
    {
        return await _userRepository.GetPagedUsers(page.Offset, page.PageSize);
    }

    public async Task<User> CreateUser(CreateUserDto createUserDto)
    {
        if (IsLoginReservedByOtherUser(createUserDto.Login))
            throw new LoginAlreadyReservedException(createUserDto.Login);
        
        ReserveLogin(createUserDto.Login);
        await Task.Delay(Delay);
        
        if (await _userRepository.IsLoginExist(createUserDto.Login))
            throw new LoginAlreadyExistException(createUserDto.Login);

        if (createUserDto.GetGroup() == GroupCode.Admin)
        {
            var admin = await _userRepository.IsAdminExist();
            if (admin)
                throw new AdminAlreadyExistException();
        }

        var user = new User
        {
            Login = createUserDto.Login,
            Password = createUserDto.Password,
            CreatedDate = GetCurrentTime(),
            UserState = new UserState { Code = StateCode.Active, Description = "Created" },
            UserGroup = new UserGroup { Code = createUserDto.GetGroup(), Description = "Added new user group" }
        };
        var createdUser = await _userRepository.CreateUser(user);
        Cancel(createUserDto.Login);
        return createdUser;
    }

    public async Task<User> DeleteUser(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user is null)
            throw new UserNotFoundException(id);
        user.UserState.Code = StateCode.Blocked;
        user.UserState.Description = "Deleted";
        var removedUser = await _userRepository.UpdateUser(user);
        return removedUser;
    }
}