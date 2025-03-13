namespace BlazorBlog.Application.Articles.GetArticleByIdForEditing
{
    public class GetArticleByIdForEditingQuery : IQuery<ArticleResponse?>
    {
        public int Id { get; init; }

    }
}
