namespace BlazorBlog.Application.Articles.CreateArticle;

public class CreateArticleCommand : ICommand<ArticleResponse>
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateTime DatePublished { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; } = false;
    public string? UserId { get; set; } = default!;
}
