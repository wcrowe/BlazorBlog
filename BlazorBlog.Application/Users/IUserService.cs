namespace BlazorBlog.Application.Users;

public interface IUserService
{
    public Task<string> GetCurrntUserIdAsync();
    public Task<bool> IsCurrentUserInRoleAsync(string role);
    public Task<bool> CurrentUserCanCreateArticleAsync();
    public Task<bool> CurrentUserCanEditArticleAsync(int articleId);
}
