using Microsoft.EntityFrameworkCore;
using vk_testing.Models;

namespace vk_testing.Context;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users => Set<User>();
    public DbSet<UserGroup> UserGroups => Set<UserGroup>();
    public DbSet<UserState> UserStates => Set<UserState>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasOne(_ => _.UserGroup).WithMany();
            user.HasOne(_ => _.UserState).WithMany();
            user.Property(_ => _.CreatedDate).HasDefaultValueSql("now()");
            user.HasIndex(_ => _.Login).IsUnique();
        });
        modelBuilder.Entity<UserGroup>(g =>
        {
            g.HasData(new UserGroup { UserGroupId = 1, Code = GroupCode.Admin }, new UserGroup { UserGroupId = 2, Code = GroupCode.User });
            g.HasIndex(_ => _.Code).IsUnique();
        });
        modelBuilder.Entity<UserState>(s =>
        {
            s.HasData(new UserState { UserStateId = 1, Code = StateCode.Active }, new UserState { UserStateId = 2, Code = StateCode.Blocked });
            s.HasIndex(_ => _.Code).IsUnique();
        });
    }
}