namespace BlazorBlog.Application.Articles
{
    public record  struct ArticleReponse(
            int Id,
            string Title,
            string? Content,
            DateTime DatePublished,
            bool IsPublished)
    {
       
    }
}
