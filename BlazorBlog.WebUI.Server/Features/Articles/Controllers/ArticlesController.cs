using BlazorBlog.Application.Articles;
using BlazorBlog.Application.Articles.GetArticlesByCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.WebUI.Server.Features.Articles.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly ISender _sender;

    public ArticlesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<List<ArticleResponse>>> GetArticlesByCurrentUser()
    {
        var result = await _sender.Send(new GetArticlesByCurrentUserQuery());
        return Ok(result.Value);
    }
}
