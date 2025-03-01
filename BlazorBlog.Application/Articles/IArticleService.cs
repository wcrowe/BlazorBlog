using BlazorBlog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles
{
    public interface IArticleService
    {
        List<Article> GetAllArticles();
       
    }
}
