using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Infrastructure.Authentication
{
    public interface ICurrentUserService
    {
        Task<string?> GetUserIdAsync();
    }
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<string?> GetUserIdAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext?.User is null)
                return null; // No user context available

            var user = await _userManager.GetUserAsync(httpContext.User);
            return user?.Id;
        }
    }

}
