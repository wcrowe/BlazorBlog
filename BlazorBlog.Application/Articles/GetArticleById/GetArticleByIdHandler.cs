using BlazorBlog.Domain.Users;

namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdHandler : IQueryHandler<GetArticleByIdQuery, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepositiory _userRepositiory;
        public GetArticleByIdHandler(IArticleRepository articleRepository, IUserRepositiory userRepositiory)
        {
            _articleRepository = articleRepository;
            _userRepositiory = userRepositiory;
        }
        public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
  
            var article = await _articleRepository.GetArticleByIdAsync(request.Id);
            var articleResponse = article.Adapt<ArticleResponse>();
            if (article is not null)
            {
                if (article.UserId is not null)
                {
                    var author = await _userRepositiory.GetUserByIdAsync(article.UserId);
                    if (author is not null)
                    {
                        articleResponse.UserName = author.UserName ?? "Unknown";
                    }else
                    {
                        articleResponse.UserName = "Unknown";
                    }
                }


            }
            if (article is null)
            {
                return Result.Fail<ArticleResponse?>("Article not found");
            }
            return articleResponse;
        }
    }
}
