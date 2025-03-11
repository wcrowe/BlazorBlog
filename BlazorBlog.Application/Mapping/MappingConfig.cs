using BlazorBlog.Application.Articles;
using BlazorBlog.Application.Articles.CreateArticle;
using BlazorBlog.Application.Articles.UpdateArticle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Article, ArticleResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.DatePublished, src => src.DatePublished)
                .Map(dest => dest.IsPublished, src => src.IsPublished);

            TypeAdapterConfig<ArticleResponse, Article>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.DatePublished, src => src.DatePublished)
                .Map(dest => dest.IsPublished, src => src.IsPublished)
                .Map(dest => dest.UserId, src => src.UserId);

            TypeAdapterConfig<CreateArticleCommand, ArticleResponse>
                .NewConfig()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.DatePublished, src => src.DatePublished)
                .Map(dest => dest.IsPublished, src => src.IsPublished)
                .Map(dest => dest.UserId, src => src.UserId);

            TypeAdapterConfig<UpdateArticleCommand, ArticleResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.DatePublished, src => src.DatePublished)
                .Map(dest => dest.IsPublished, src => src.IsPublished);
        }
    }
}
