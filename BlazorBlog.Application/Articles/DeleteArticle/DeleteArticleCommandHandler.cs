using BlazorBlog.Application.Users;

namespace BlazorBlog.Application.Articles.DeleteArticle
{
    public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserService _userService;
        public DeleteArticleCommandHandler(IArticleRepository articleRepository, IUserService userService)
        {
            _articleRepository = articleRepository;
            _userService = userService;
        }
        public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            if (!await _userService.CurrentUserCanEditArticleAsync(request.Id))
            {
                return Result.Fail<ArticleResponse?>("You are not allowed to delete. How did you get here?");
            }
            var deleted = await _articleRepository.DeleteArticleAsync(request.Id);
            if (deleted)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Article not found");
            }
        }
    }
}
