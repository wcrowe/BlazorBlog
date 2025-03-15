
namespace BlazorBlog.Application.Articles.CreateArticle;


public class CreateArticleCommandHandler(IArticleRepository articleRepository, IUserService userService)
    : ICommandHandler<CreateArticleCommand, ArticleResponse>
{
    public async Task<Result<ArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newArticle = request.Adapt<Article>();
            newArticle.UserId = await userService.GetCurrntUserIdAsync();
            if (!await userService.CurrentUserCanCreateArticleAsync())
            {
                return FailingResult();
            }
            var article = await articleRepository.CreateArticleAsync(newArticle);
            return Result.Ok(article.Adapt<ArticleResponse>());
        }
        catch (UserNotAuthorizedException)
        {
            return FailingResult();
        }
    }

    private static Result<ArticleResponse> FailingResult()
    {
        return Result.Fail<ArticleResponse>("You are not allowed to create articles");
    }
}



