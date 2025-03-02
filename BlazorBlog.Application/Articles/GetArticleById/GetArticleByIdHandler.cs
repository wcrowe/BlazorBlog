namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdHandler : IQueryHandler<GetArticleByIdQuery, ArticleReponse?>
    {
        private readonly IArticleRepository _articleRepository;
        public GetArticleByIdHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<Result<ArticleReponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetArticleByIdAsync(request.Id);
            if (article is null)
            {
                return Result.Fail<ArticleReponse?>("Article not found");
            }
            return article.Adapt<ArticleReponse>();
        }
    }
}
