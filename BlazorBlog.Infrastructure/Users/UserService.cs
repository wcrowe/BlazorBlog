using BlazorBlog.Application.Exceptions;
using BlazorBlog.Application.Users;
using BlazorBlog.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BlazorBlog.Infrastructure.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ArticleRepository _articleRepository;
    public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, ArticleRepository articleRepository)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _articleRepository = articleRepository;
    }
    public async Task<string?> GetCurrntUserIdAsync()
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            throw new UserNotAutherizedException();
        }
        return user.Id;
    }

    public async Task<bool> IsCurrentUserInRoleAsync(string role)
    {
        var user = await GetCurrentUserAsync();
        var result = user is not null && await _userManager.IsInRoleAsync(user, role);
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

        var article = await _articleRepository.GetArticleByIdAsync(articleId);
        if (article is null)
        {
            return false;
        }
        return isAdmin || (isWriter && article.UserId == user.Id);
    }

    private async Task<User?> GetCurrentUserAsync()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            return null;
        }
        return await _userManager.GetUserAsync(user);
    }
}
