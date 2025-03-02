namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdQuery : IQuery<ArticleReponse?>
    {
        public int Id { get; set; }

    }
}
