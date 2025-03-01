using BlazorBlog.Domain.Articles;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ArticleReponse>
    {
        private readonly IArticleRepository _articleRepository;
        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<ArticleReponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {

            var newArticle = request.Adapt<Article>();
            var article = await _articleRepository.CreateArticleAsync(newArticle);
            return article.Adapt<ArticleReponse>(); 
        }
    }
}
