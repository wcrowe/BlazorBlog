using BlazingBlog.Domain.Users;
using BlazorBlog.Application.Articles.GetArticleById;
using BlazorBlog.Application.Users;
using BlazorBlog.Domain.Users;

namespace BlazorBlog.Application.Articles.GetArticleByIdForEditing;

public class GetArticleByIdForEditingQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository  ,  IUserService userService)
    : IQueryHandler<GetArticleByIdForEditingQuery, ArticleResponse?>
{
    public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdForEditingQuery request, CancellationToken cancellationToken)
    {
        var canEdit = await userService.CurrentUserCanEditArticleAsync(request.Id);
        if (!canEdit)
        {
            return Result.Fail<ArticleResponse?>("You do not have permission to edit this article.");
        }

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


