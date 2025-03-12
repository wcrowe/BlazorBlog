namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdQuery : IQuery<ArticleResponse?>
    {
        public int Id { get; init; }

    }
}
