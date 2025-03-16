namespace BlazorBlog.Application.Articles;

public interface IArticleOverviewService
{
    Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync();
    Task<ArticleResponse?> TogglePublishArticleAsync(int articlId);
}
