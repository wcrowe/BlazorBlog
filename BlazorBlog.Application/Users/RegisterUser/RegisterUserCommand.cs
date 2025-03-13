namespace BlazorBlog.Application.Users.RegisterUser;
public class RegisterUserCommand : ICommand
{
    public required string UserName { get; init; }
    public required string UserEmail { get; init; }
    public required string Password { get; init; }
}