using BlazingBlog.Domain.Users;

namespace BlazorBlog.Application.Articles.UpdateArticle
{
    public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var existingArticle = await _articleRepository.GetArticleByIdAsync(request.Id);
            if (existingArticle is null)
            {
                return Result.Fail<ArticleResponse?>("Article not found");
            }

            existingArticle.Title = request.Title;
            existingArticle.Content = request.Content;
            existingArticle.DatePublished = request.DatePublished;
            existingArticle.IsPublished = request.IsPublished;

            var updatedArticle = await _articleRepository.UpdateArticleAsync(existingArticle);
            if (updatedArticle is null)
            {
                return Result.Fail<ArticleResponse?>("Failed to update article");
            }

            var response = updatedArticle.Adapt<ArticleResponse>();
            if (updatedArticle.UserId is not null)
            {
                var author = await _userRepository.GetUserByIdAsync(updatedArticle.UserId);
                response.UserName = author?.UserName ?? "Unknown";
            }
            else
            {
                response.UserName = "Unknown";
            }
            return response;
        }
    }
}