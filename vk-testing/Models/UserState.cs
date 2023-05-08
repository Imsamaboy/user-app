using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vk_testing.Models;

public class UserState
{
    [Key, ForeignKey("User")]
    public long UserStateId { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
}