using BlazorBlog.Domain.Users;

namespace BlazingBlog.Domain.Users;

public interface IUserRepository
{
    Task<IUser?> GetUserByIdAsync(string userId);
}
