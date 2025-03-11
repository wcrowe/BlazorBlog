using BlazorBlog.Application.Exceptions;
using BlazorBlog.Application.Users;
using BlazorBlog.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BlazorBlog.Application.Articles;
using BlazorBlog.Domain.Articles;

namespace BlazorBlog.Infrastructure.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IArticleRepository articleRepository;

    public UserService(
        UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor,
        IArticleRepository articleRepository)
    {
        this.userManager = userManager;
        this.httpContextAccessor = httpContextAccessor;
        this.articleRepository = articleRepository;
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
}
