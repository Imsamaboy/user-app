using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_testing.Models;

public class UserState
{
    [Key, ForeignKey("User")]
    [Column("user_state_id")]
    public long UserStateId { get; set; }
    
    [Required]
    [Column("code")]
    public StateCode Code { get; set; }
    
    [Required]
    [Column("description")]
    public string Description { get; set; }
    
    public virtual User User { get; set; }
}