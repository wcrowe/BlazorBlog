using BlazingBlog.Domain.Users;
using BlazorBlog.Domain.Users;

namespace BlazorBlog.Application.Articles.GetArticleById;

public class GetArticleByIdQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository)
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
            }
            else
            {
                articleResponse.UserName = "Unknown";
            }
            return articleResponse;
        }
    }
}
