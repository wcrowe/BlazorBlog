namespace BlazorBlog.Application.Articles.CreateArticle;

public class CreateArticleCommand : ICommnd<ArticleResponse>
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public DateTime DatePublished { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; } = false;
}
