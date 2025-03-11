namespace BlazorBlog.Application.Exceptions;

[Serializable]
public class UserNotAutherizedException : Exception
{
    public UserNotAutherizedException()
    {
    }

    public UserNotAutherizedException(string? message) : base(message)
    {
    }

    public UserNotAutherizedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}