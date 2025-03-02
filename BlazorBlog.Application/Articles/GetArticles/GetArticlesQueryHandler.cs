namespace BlazorBlog.Application.Articles.GetArticles
{
    public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, List<ArticleReponse>>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticlesQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Result<List<ArticleReponse>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles =  await _articleRepository.GetAllArticlesAsync();
            return articles.Adapt<List<ArticleReponse>>();
        }
    }
}