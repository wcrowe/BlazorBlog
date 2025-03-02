namespace BlazorBlog.Application.Articles.UpdateArticle
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleReponse?>
    {
        private readonly IArticleRepository _articleRepository;
        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<Result<ArticleReponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var updateArticle = request.Adapt<Article>();
            var article = await _articleRepository.UpdateArticleAsync(updateArticle);
            if (article is null)
            {
                return Result.Fail<ArticleReponse?>("Article not found");
            }
            return article.Adapt<ArticleReponse>();

        }
    }
}
