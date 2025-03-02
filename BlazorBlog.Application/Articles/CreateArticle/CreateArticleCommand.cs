﻿using BlazorBlog.Domain.Articles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBlog.Application.Abstractions.RequestHandling;  

namespace BlazorBlog.Application.Articles.CreateArticle
{
    public class CreateArticleCommand : ICommnd<ArticleReponse>
    {
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime DatePublished { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = false;
    }
}
