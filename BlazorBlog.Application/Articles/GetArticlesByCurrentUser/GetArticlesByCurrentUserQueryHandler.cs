
using BlazorBlog.Application.Articles.GetArticlesByCurrentUser;

namespace BlazorBlog.Application.Articles.GetArticlesByUser;

public class GetArticlesByCurrentUserQueryHandler(IArticleRepository articleRepository, IUserService userService) : IQueryHandler<GetArticlesByCurrentUserQuery, List<ArticleResponse>>
{
    public async Task<Result<List<ArticleResponse>>> Handle(GetArticlesByCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var usrId = await userService.GetCurrntUserIdAsync();
        var articles = await articleRepository.GetArticlesByUserAsync(usrId);
        var results = articles.Adapt<List<ArticleResponse>>();
        return results.OrderByDescending(x => x.DatePublished).ToList();
    }
}
