using Microsoft.EntityFrameworkCore;
using vk_testing.Models;
using vk_testing.Repositories.Interfaces;

namespace vk_testing.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly DbContext _dbContext;

    public UserRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // TODO: Optional проверки
    public async Task<User> GetUserById(Guid id)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbContext.Set<User>().ToListAsync();
    }

    public async Task<IEnumerable<User>> GetPagedUsers(int pageNumber, int pageSize)
    {
        return await _dbContext.Set<User>()
            .OrderBy(u => u.CreatedDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task CreateUser(User user)
    {
        await _dbContext.Set<User>().AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _dbContext.Set<User>().Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUser(Guid id)
    {
        var user = await GetUserById(id);
        if (user != null)
        {
            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}