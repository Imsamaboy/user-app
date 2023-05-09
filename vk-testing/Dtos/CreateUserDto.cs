using System.ComponentModel.DataAnnotations;
using vk_testing.Models;

namespace vk_testing.Dtos;

public class CreateUserDto
{
    [Required(ErrorMessage = $"{nameof(Login)} required")]
    public string Login { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(Password)} required")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(GroupCode)} required")]
    [IsEnumDisplay<GroupCode>($"Group codes does not contain name passed to the {nameof(GroupCode)}")]
    public string GroupCode { get; set; } = null!;

    public GroupCode GetGroup() => Enum.Parse<GroupCode>(GroupCode, ignoreCase: true);
}