namespace BlazorBlog.Application.Articles.UpdateArticle
{
    public class UpdateArticleCommand : ICommnd<ArticleReponse?>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime DatePublished { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = false;
    }
}
