using BlazorBlog.Domain.Articles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<Article>>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticlesQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<Article>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _articleRepository.GetAllArticlesAsync();
        }
    }
}