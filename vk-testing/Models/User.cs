using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_testing.Models;

public class User
{
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Required]
    [Column("login")]
    public string Login { get; set; }
    
    [Required]
    [Column("password")]
    public string Password { get; set; }
    
    [Required]
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    
    public long UserGroupId { get; set; }
    public long UserStateId { get; set; }
    
    public virtual UserGroup UserGroup { get; set; }
    public virtual UserState UserState { get; set; }
}