using BlazorBlog.Domain.Articles;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdQuery, ArticleReponse?>
    {
        private readonly IArticleRepository _articleRepository;
        public GetArticleByIdHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<ArticleReponse?> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetArticleByIdAsync(request.Id);
            if (article is null)
            {
                return null;
            }
            return article.Adapt<ArticleReponse>();
        }
    }
}
