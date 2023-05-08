namespace vk_testing.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }

    // Foreign keys
    public long UserGroupId { get; set; }
    public long UserStateId { get; set; }

    // Navigation properties
    public virtual UserGroup UserGroup { get; set; }
    public virtual UserState UserState { get; set; }
}