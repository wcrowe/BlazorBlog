using BlazorBlog.Domain.Users;

namespace BlazorBlog.Application.Articles.GetArticles
{
    public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, List<ArticleResponse>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepositiory _userRepositiory;

        public GetArticlesQueryHandler(IArticleRepository articleRepository, IUserRepositiory userRepositiory)
        {
            _articleRepository = articleRepository;
            _userRepositiory = userRepositiory;
        }

        public async Task<Result<List<ArticleResponse>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetAllArticlesAsync();
            var respose = new List<ArticleResponse>();
            if (articles is not null)
            {
                foreach (var article in articles)
                {
                    var articleResponse = article.Adapt<ArticleResponse>();
                    if (article.UserId is null)
                    {
                        articleResponse.UserName = "Unknown";
                        respose.Add(articleResponse);
                        continue;
                    }
                    var auther = await _userRepositiory.GetUserByIdAsync(article.UserId);
                    if (auther is not null)
                    {
                        articleResponse.UserName = auther.UserName ?? "Unknown";
                    }
                    respose.Add(articleResponse);

                }

            }
            return respose.OrderByDescending(x => x.DatePublished).ToList();
        }
    }
}