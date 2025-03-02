namespace BlazorBlog.Application.Articles.CreateArticle;

public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, ArticleReponse>
{
    private readonly IArticleRepository _articleRepository;
    public CreateArticleCommandHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }
    public async Task<Result<ArticleReponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {

        var newArticle = request.Adapt<Article>();
        var article = await _articleRepository.CreateArticleAsync(newArticle);
        return article.Adapt<ArticleReponse>(); 
    }
}
