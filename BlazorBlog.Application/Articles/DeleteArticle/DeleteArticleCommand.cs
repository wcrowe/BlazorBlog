﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

}
