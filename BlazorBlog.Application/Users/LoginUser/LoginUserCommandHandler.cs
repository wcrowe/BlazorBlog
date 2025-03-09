using BlazorBlog.Application.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Users.LoginUser
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _authenticationService.LoginUserAsync(request.UserName, request.Password);
            return success ? Result.Ok() : Result.Fail("Invalid username or password");

        }
    }
}
