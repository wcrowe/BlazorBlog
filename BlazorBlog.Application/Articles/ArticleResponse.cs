namespace BlazorBlog.Application.Articles;
public record struct ArticleResponse(int Id, string Title, 
    string? Content, DateTime DatePublished, bool IsPublished, 
    string UserId, string UserName, bool CanEdit);

//{
//    public int Id { get; set; }
//    public required string Title { get; set; }
//    public string? Content { get; set; }
//    public DateTime DatePublished { get; set; }
//    public bool IsPublished { get; set; }
//    public string? UserId { get; set; } = null;
//    public string? UserName { get; set; } = null;
//}





