namespace BlazorBlog.Application.Abstractions.RequestHandling;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand //IRequest<Result>
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommnd<TResponse> //IRequest<Result<TResponse>>
{
}
