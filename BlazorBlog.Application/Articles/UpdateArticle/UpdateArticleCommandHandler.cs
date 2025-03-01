using BlazorBlog.Domain.Articles;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, ArticleReponse?>
    {
        private readonly IArticleRepository _articleRepository;
        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<ArticleReponse?> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetArticleByIdAsync(request.Id);
            if (article is null)
            {
                return null;
            }
            article.Title = request.Title;
            article.Content = request.Content;
            article.DatePublished = request.DatePublished;
            article.IsPublished = request.IsPublished;
            await _articleRepository.UpdateArticleAsync(article);
            return article.Adapt<ArticleReponse>();
        }
    }
}
