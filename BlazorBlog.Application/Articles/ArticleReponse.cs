using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles
{
    public record  struct ArticleReponse(
            int Id,
            string Title,
            string? Content,
            DateTime DatePublished,
            bool IsPublished)
    {
       
    }
}
