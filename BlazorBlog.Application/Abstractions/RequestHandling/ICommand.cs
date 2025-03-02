namespace BlazorBlog.Application.Abstractions.RequestHandling;

public interface ICommand : IRequest<Result>
{
}
public interface ICommnd<TResponse> : IRequest<Result<TResponse>>
{
}
