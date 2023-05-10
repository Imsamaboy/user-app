using Microsoft.EntityFrameworkCore;
using vk_testing.Context;
using vk_testing.Models;
using vk_testing.Repositories.Interfaces;

namespace vk_testing.Repositories.Implementations;

public class UserGroupRepository: IUserGroupRepository
{
    private readonly ApplicationContext _context;

    public UserGroupRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    private IQueryable<UserGroup> UserGroups => _context.UserGroups;
    
    public async Task<UserGroup> GetUserGroupByCode(GroupCode code)
    {
        return await UserGroups.FirstAsync(userGroup => userGroup.Code == code);
    }
}