using BlazorBlog.Application.Users;

namespace BlazorBlog.Application.Articles.DeleteArticle
{
    public class DeleteArticleCommandHandler(IArticleRepository articleRepository, IUserService userService)
        : ICommandHandler<DeleteArticleCommand>
    {
        public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            if (!await userService.CurrentUserCanEditArticleAsync(request.Id))
            {
                return Result.Fail<ArticleResponse?>("You are not allowed to delete. How did you get here?");
            }
            var deleted = await articleRepository.DeleteArticleAsync(request.Id);
            if (deleted)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Article not found");
            }
        }
    }
}
