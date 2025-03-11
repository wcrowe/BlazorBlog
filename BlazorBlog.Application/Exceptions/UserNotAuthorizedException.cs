namespace BlazorBlog.Application.Exceptions;

[Serializable]
public class UserNotAuthorizedException : Exception
{
    public UserNotAuthorizedException()
    {
    }

    public UserNotAuthorizedException(string? message) : base(message)
    {
    }

    public UserNotAuthorizedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}