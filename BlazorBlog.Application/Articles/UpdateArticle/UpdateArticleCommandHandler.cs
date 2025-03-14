using BlazorBlog.Application.Users;

namespace BlazorBlog.Application.Articles.UpdateArticle;

public class UpdateArticleCommandHandler(IArticleRepository articleRepository, IUserRepository userRepository, IUserService userService) : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
{
    public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var articleToUpdate = request.Adapt<Article>();
        if (!await userService.CurrentUserCanEditArticleAsync(articleToUpdate.Id))
        {
            return Result.Fail<ArticleResponse?>("You are not allowed to edit. How did you get here?");
        }
        var updatedArticle = await articleRepository.UpdateArticleAsync(articleToUpdate);
        var response = updatedArticle.Adapt<ArticleResponse>();
        if (response.UserId is not null)
        {
            var author = await userRepository.GetUserByIdAsync(response.UserId);
            response.UserName = author?.UserName ?? "Unknown";
        }
        else
        {
            response.UserName = "Unknown";
        }
        return response;
    }
}