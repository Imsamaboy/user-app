using vk_testing.Repositories.Implementations;
using vk_testing.Repositories.Interfaces;
using vk_testing.Services.Implementations;
using vk_testing.Services.Interfaces;

namespace vk_testing.Extensions;

public static class ServicesExtension
{
    public static void AddDomain(this IServiceCollection services)
    {
        AddDomainServices(services);
        AddRepositories(services);
    }

    private static void AddDomainServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthService, AuthorizationService>();
    }
}