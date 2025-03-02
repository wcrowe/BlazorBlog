namespace BlazorBlog.Application.Articles.CreateArticle;

public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, ArticleResponse>
{
    private readonly IArticleRepository _articleRepository;
    public CreateArticleCommandHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }
    public async Task<Result<ArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var newArticle = request.Adapt<Article>();

        // Ensure Id is not set manually if the DB handles it
        newArticle.Id = 0; // Ensure EF Core treats this as a new entity

        var article = await _articleRepository.CreateArticleAsync(newArticle);
        return article.Adapt<ArticleResponse>();

        //var newArticle = request.Adapt<Article>();
        //var article = await _articleRepository.CreateArticleAsync(newArticle);
        //return article.Adapt<ArticleResponse>();
    }
}
