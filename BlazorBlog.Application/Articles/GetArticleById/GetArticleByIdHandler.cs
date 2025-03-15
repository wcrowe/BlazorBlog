namespace BlazorBlog.Application.Articles.GetArticleById;

public class GetArticleByIdQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository, IUserService userService)
    : IQueryHandler<GetArticleByIdQuery, ArticleResponse?>
{
    public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await articleRepository.GetArticleByIdAsync(request.Id);


        if (article is null)
        {
            return Result.Fail<ArticleResponse?>("The article does not exist.");
        }
        else
        {
            var articleResponse = article.Adapt<ArticleResponse>();
            if (article.UserId is not null)
            {
                var author = await userRepository.GetUserByIdAsync(article.UserId);
                articleResponse.UserName = author?.UserName ?? "Unknown";
                articleResponse.CanEdit = await userService.CurrentUserCanEditArticleAsync(article.Id);
                articleResponse.UserId = article.UserId;
            }
            else
            {
                articleResponse.UserName = "Unknown";
            }
            return articleResponse;
        }
    }
}
