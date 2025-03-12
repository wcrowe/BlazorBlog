using BlazorBlog.Application.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Users.LoginUser
{
    public class LoginUserCommandHandler(IAuthenticationService authenticationService)
        : ICommandHandler<LoginUserCommand>
    {
        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var success = await authenticationService.LoginUserAsync(request.UserName, request.Password);
            return success ? Result.Ok() : Result.Fail("Invalid username or password");

        }
    }
}
