using BlazorBlog.Application.Abstractions.RequestHandling;
using BlazorBlog.Application.Authentication;

namespace BlazorBlog.Application.Users.RegisterUser;

public class RegisterUserCommandHandler(IAuthenticationService authenticationService)
    : ICommandHandler<RegisterUserCommand>
{
    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var registerUserResponse = await authenticationService.RegisterUserAsync(request.UserName, request.UserEmail, request.Password);
        if (registerUserResponse.Successed)
        {
            return Result.Ok();
        }
        else
        {
            return Result.Fail($"{string.Join(", ", registerUserResponse.Errors)}");
        }
    }
}