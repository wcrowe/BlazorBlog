using BlazorBlog.Domain.Articles;
using BlazorBlog.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace BlazorBlog.Infrastructure.Users;

public class User : IdentityUser, IUser
{
    public List<Article> Articles { get; set; } = [];
}
