using vk_testing.Models;

namespace vk_testing.Dtos;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }

    public UserGroup UserGroup { get; set; }
    public UserState UserState { get; set; }

    public UserDto(User user)
    {
        UserId = user.UserId;
        Login = user.Login;
        Password = user.Password;
        CreatedDate = user.CreatedDate;
        UserGroup = user.UserGroup;
        UserState = user.UserState;
    }

    public static explicit operator UserDto(User user)
    {
        return new UserDto(user);
    }
}