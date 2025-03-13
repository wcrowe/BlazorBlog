namespace BlazorBlog.Application.Authentication;

public class RegisterUserResponse
{
    public bool Successed { get; set; }
    public List<string> Errors { get; set; } = [];
}