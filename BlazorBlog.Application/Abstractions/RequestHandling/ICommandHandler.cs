using BlazorBlog.Domain.Abstractions;
using MediatR;

namespace BlazorBlog.Application.Abstractions.RequestHandling
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommnd //IRequest<Result>
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommnd<TResponse> //IRequest<Result<TResponse>>
    {
    }
}
