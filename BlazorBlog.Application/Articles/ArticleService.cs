using BlazorBlog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles
{
    public class ArticleService : IArticleService
    {
        public List<Article> GetAllArticles() => [
                new Article()
                {
                    Id = 1,
                    Title = "First Article",
                    Content = "This is the content of the first article",
                    DatePublished = DateTime.Now,
                    IsPublished = true
                },
                new Article()
                {
                    Id = 2,
                    Title = "Second Article",
                    Content = "This is the content of the second article",
                    DatePublished = DateTime.Now,
                    IsPublished = true
                },
                new Article()
                {
                    Id = 3,
                    Title = "Third Article",
                    Content = "This is the content of the third article",
                    DatePublished = DateTime.Now,
                    IsPublished = true
                }
            ];
    }
}
