using BlazorBlog.Domain.Users;
using BlazorBlog.Infrastructure.Users;
using Microsoft.AspNetCore.Identity;

namespace BlazorBlog.Infrastructure.Repository;

public class UserRepositiory : IUserRepository
{
    private readonly UserManager<User>? _userManager;

    public UserRepositiory(UserManager<User>? userManager)
    {
        _userManager = userManager;
    }

    public Task<List<IUser>> GetAllUsersAsync()
    {
       return await _userManager.userManager!.GetAll;
    }

    public async Task<IUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager!.FindByIdAsync(userId);
    }
}