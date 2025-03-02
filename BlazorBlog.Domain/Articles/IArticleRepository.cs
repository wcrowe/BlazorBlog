namespace BlazorBlog.Domain.Articles
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllArticlesAsync();
        Task<Article> CreateArticleAsync(Article article);
        Task<Article?> UpdateArticleAsync(Article article);
        Task<Article?> GetArticleByIdAsync(int id);
        Task<bool> DeleteArticleAsync(int id);
    }
}
