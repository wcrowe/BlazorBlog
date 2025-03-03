
using BlazorBlog.Application.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BlazorBlog.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded;

        }

        public async Task<RegisterUserResponse> RegisterUserAsync(string username, string email, string password)
        {
            var newUser = new User
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(newUser, password);
            var response = new RegisterUserResponse()
            {
                Successed = result.Succeeded,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
            return response;
        }
    }
}
