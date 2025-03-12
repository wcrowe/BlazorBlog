using BlazingBlog.Domain.Users;
using BlazorBlog.Application.Users;

namespace BlazorBlog.Application.Articles.UpdateArticle
{
    public class UpdateArticleCommandHandler(IArticleRepository articleRepository, IUserRepository userRepository, IUserService userService) : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserService userService = userService;

        public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return Result.Fail<ArticleResponse?>("Request is null");
            }
            var articleToUpdate = request.Adapt<Article>();

            if (!await userService.CurrentUserCanEditArticleAsync(articleToUpdate.Id))
            {
                return Result.Fail<ArticleResponse?>("You are not allowed to edit. How did you get here?");
            }


            var updatedArticle = await _articleRepository.UpdateArticleAsync(articleToUpdate);
  

            var response = updatedArticle.Adapt<ArticleResponse>();
            if (response.UserId is not null)
            {
                var author = await _userRepository.GetUserByIdAsync(response.UserId);
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