using Microsoft.EntityFrameworkCore;
using vk_testing.Context;
using vk_testing.Models;
using vk_testing.Repositories.Interfaces;

namespace vk_testing.Repositories.Implementations;

public class UserStateRepository: IUserStateRepository
{
    private readonly ApplicationContext _context;

    public UserStateRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    private IQueryable<UserState> UserStates => _context.UserStates;
    
    public async Task<UserState> GetUserStateByCode(StateCode code)
    {
        return await UserStates.FirstAsync(userState => userState.Code == code);
    }
}