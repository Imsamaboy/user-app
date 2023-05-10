using vk_testing.Services.Interfaces;

namespace vk_testing.Services.Implementations;

public class AuthorizationService: IAuthService
{
    public bool HasUserAccess(string username, string password)
    {
        return username == "admin" && password == "123";
    }
}