using BlazorBlog.Application.Exceptions;
using BlazorBlog.Application.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BlazorBlog.Domain.Articles;

namespace BlazorBlog.Infrastructure.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IArticleRepository articleRepository;
    private readonly RoleManager<IdentityRole> roleManager;

    public UserService(
        UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor,
        IArticleRepository articleRepository,
        RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.httpContextAccessor = httpContextAccessor;
        this.articleRepository = articleRepository;
        this.roleManager = roleManager;
    }

    public async Task<string> GetCurrntUserIdAsync()
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            throw new UserNotAuthorizedException();
        }
        return user.Id;
    }

    public async Task<bool> IsCurrentUserInRoleAsync(string role)
    {
        var user = await GetCurrentUserAsync();
        var result = user is not null && await userManager.IsInRoleAsync(user, role);
        return result;
    }

    public async Task<bool> CurrentUserCanCreateArticleAsync()
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            return false;
        }
        var isWriter = await IsCurrentUserInRoleAsync("Writer");
        var isAdmin = await IsCurrentUserInRoleAsync("Admin");
        return isAdmin || isWriter;
    }
    public async Task<bool> CurrentUserCanEditArticleAsync(int articleId)
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            return false;
        }
        var isWriter = await IsCurrentUserInRoleAsync("Writer");
        var isAdmin = await IsCurrentUserInRoleAsync("Admin");

        var article = await articleRepository.GetArticleByIdAsync(articleId);
        if (article is null)
        {
            return false;
        }
        return isAdmin || (isWriter && article.UserId == user.Id);
    }

    private async Task<User?> GetCurrentUserAsync()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            return null;
        }
        return await userManager.GetUserAsync(user);
    }

    public async Task<List<string>> GetUserRolesAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return new List<string>();
        }
        var roles = await userManager.GetRolesAsync(user);
        return roles.ToList();
    }

    public async Task AddRoleToUserAsync(string userId, string roleName)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found.");
        }

        if (!await roleManager.RoleExistsAsync(roleName))
        {
            var resultCreateRole = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (!resultCreateRole.Succeeded)
            {
                var errors = string.Join(", ", resultCreateRole.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create role: {errors}");
            }
        }

        if (!await userManager.IsInRoleAsync(user, roleName))
        {
            var resultAddRole = await userManager.AddToRoleAsync(user, roleName);
            if (!resultAddRole.Succeeded)
            {
                var errors = string.Join(", ", resultAddRole.Errors.Select(e => e.Description));
                throw new Exception($"Failed to add role to user: {errors}");
            }
        }
    }
}

