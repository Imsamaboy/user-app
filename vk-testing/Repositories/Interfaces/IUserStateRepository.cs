using vk_testing.Models;

namespace vk_testing.Repositories.Interfaces;

public interface IUserStateRepository
{
    public Task<UserState> GetUserStateByCode(StateCode code);
}