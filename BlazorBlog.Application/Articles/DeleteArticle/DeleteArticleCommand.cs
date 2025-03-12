

namespace BlazorBlog.Application.Articles.DeleteArticle
{
    public class DeleteArticleCommand : ICommand
    {
        public int Id { get; init; }
    }

}
