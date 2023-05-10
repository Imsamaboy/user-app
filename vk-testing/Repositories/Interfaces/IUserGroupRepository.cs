using vk_testing.Models;

namespace vk_testing.Repositories.Interfaces;

public interface IUserGroupRepository
{
    public Task<UserGroup> GetUserGroupByCode(GroupCode code);
}