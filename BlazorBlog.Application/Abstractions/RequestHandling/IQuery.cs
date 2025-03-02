using BlazorBlog.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Abstractions.RequestHandling
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
