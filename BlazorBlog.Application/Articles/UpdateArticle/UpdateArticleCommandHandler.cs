namespace BlazorBlog.Application.Articles.UpdateArticle
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;
        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var updateArticle = request.Adapt<Article>();
            var article = await _articleRepository.UpdateArticleAsync(updateArticle);
            if (article is null)
            {
                return Result.Fail<ArticleResponse?>("Article not found");
            }
            return article.Adapt<ArticleResponse>();

        }
    }
}
