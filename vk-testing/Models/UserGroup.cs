using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_testing.Models;

public class UserGroup
{
    [Key, ForeignKey("User")]
    [Column("user_group_id")]
    public long UserGroupId { get; set; }
    
    [Required]
    [Column("code")]
    public GroupCode Code { get; set; }
    
    [Required]
    [Column("description")]
    public string Description { get; set; }
    
    public virtual User User { get; set; }
}
