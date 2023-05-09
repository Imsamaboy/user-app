namespace vk_testing.Services.Interfaces;

public interface IAuthService
{
    public bool HasUserAccess(string username, string password);
}