using BlazorBlog.Domain.Users;
using BlazorBlog.Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Infrastructure.Repository;

public class UserRepositiory : IUserRepository
{
    private readonly UserManager<User>? _userManager;

    public UserRepositiory(UserManager<User>? userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<IUser>> GetAllUsersAsync()
    {
       return await _userManager!.Users.Select(u => u as IUser).ToListAsync();
    }

    public async Task<IUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager!.FindByIdAsync(userId);
    }
}