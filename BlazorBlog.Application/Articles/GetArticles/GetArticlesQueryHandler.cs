using BlazorBlog.Application.Users;

namespace BlazorBlog.Application.Articles.GetArticles;

    public class GetArticlesQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository, IUserService userService)
        : IQueryHandler<GetArticlesQuery, List<ArticleResponse>>
    {
        public async Task<Result<List<ArticleResponse>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await articleRepository.GetAllArticlesAsync();

            var response = new List<ArticleResponse>();

            foreach (var article in articles)
            {
                var articleResponse = article.Adapt<ArticleResponse>();
                if (article.UserId is not null)
                {
                    var author = await userRepository.GetUserByIdAsync(article.UserId);
                    articleResponse.UserName = author?.UserName ?? "Unknown";
                articleResponse.UserId = article.UserId;
                articleResponse.CanEdit = await userService.CurrentUserCanEditArticleAsync(article.Id); 
            }
                else
                {
                    articleResponse.UserName = "Unknown";
                }
                response.Add(articleResponse);
            }
            // articles.Adapt<List<ArticleResponse>>();
            return response.OrderByDescending(x => x.DatePublished).ToList();
        }
    }
