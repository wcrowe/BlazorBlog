﻿using BlazorBlog.Domain.Articles;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper; 

namespace BlazorBlog.Application.Articles.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<ArticleReponse>>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticlesQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<ArticleReponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles =  await _articleRepository.GetAllArticlesAsync();
            return articles.Adapt<List<ArticleReponse>>();
        }
    }
}