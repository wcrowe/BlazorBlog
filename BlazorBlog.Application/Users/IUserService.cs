namespace BlazorBlog.Application.Users;

public interface IUserService
{
    public Task<string> GetCurrntUserIdAsync();
    public Task<bool> IsCurrentUserInRoleAsync(string role);
    public Task<bool> CurrentUserCanCreateArticleAsync();
    public Task<bool> CurrentUserCanEditArticleAsync(int articleId);
    public Task<List<string>> GetUserRolesAsync(string userId);
    public Task AddRoleToUserAsync(string userId, string roleName);
    public Task RemoveRoleFromUserAsync(string userId, string roleName);
}
