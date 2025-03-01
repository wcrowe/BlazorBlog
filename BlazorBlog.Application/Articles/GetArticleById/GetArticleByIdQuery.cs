using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<ArticleReponse?>
    {
        public int Id { get; set; }

    }
}
