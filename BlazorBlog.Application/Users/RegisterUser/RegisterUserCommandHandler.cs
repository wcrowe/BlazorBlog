using BlazorBlog.Application.Abstractions.RequestHandling;
using BlazorBlog.Application.Authentication;

namespace BlazorBlog.Application.Users.RegisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerUserResponse = await _authenticationService.RegisterUserAsync(request.UserName, request.UserEmail, request.Password);
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
}
