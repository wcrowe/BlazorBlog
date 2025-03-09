using BlazingBlog.Domain.Users;
using BlazorBlog.Domain.Users;

namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdQueryHandler : IQueryHandler<GetArticleByIdQuery, ArticleResponse?>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;
        public GetArticleByIdQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _articleRepository.GetArticleByIdAsync(request.Id);
            var response = new ArticleResponse();

            if (result is null)
            {
                return Result.Fail<ArticleResponse?>("The article does not exist.");
            }
            else
            {
                response = result.Adapt<ArticleResponse>();
                if (result.UserId is not null)
                {
                    var author = await _userRepository.GetUserByIdAsync(result.UserId);
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
}
