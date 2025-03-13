using BlazorBlog.Domain.Articles;

namespace BlazorBlog.Domain.Users;

public interface IUser
{
    public string Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public List<Article> Articles { get; set; }
    //string PasswordHash { get; set; }
    //string SecurityStamp { get; set; }
    //string DisplayName { get; set; }
    //string ProfileImageUrl { get; set; }
    //string ProfileThumbnailUrl { get; set; }
    //string ProfileDescription { get; set; }
    //DateTime CreatedAt { get; set; }
    //DateTime UpdatedAt { get; set; }
    //bool IsDeleted { get; set; }
    //DateTime? DeletedAt { get; set; }
}
