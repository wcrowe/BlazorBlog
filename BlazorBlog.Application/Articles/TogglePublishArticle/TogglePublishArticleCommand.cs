
namespace BlazorBlog.Application.Articles.TogglePublish;

public class TogglePublishArticleCommand : ICommand<ArticleResponse>
{
    public int ArticleId { get; set; }

}