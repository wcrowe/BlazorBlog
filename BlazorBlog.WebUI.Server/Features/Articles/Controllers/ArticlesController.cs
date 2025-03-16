using BlazorBlog.Application.Articles;
using BlazorBlog.Application.Articles.GetArticlesByCurrentUser;
using BlazorBlog.Application.Articles.TogglePublish;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.WebUI.Server.Features.Articles.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{

    private readonly IArticleOverviewService _articleOverviewService;

    public ArticlesController(IArticleOverviewService articleOverviewService)
    {
        _articleOverviewService = articleOverviewService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<ArticleResponse>>> GetArticlesByCurrentUser()
    {
        var result = await _articleOverviewService.GetArticlesByCurrentUserAsync();
        return Ok(result);
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<ActionResult<ArticleResponse>> TogglePublishArticle(int id)
    {
        var result = await _articleOverviewService.TogglePublishArticleAsync(id);
        if (result is null)
        {
            return BadRequest();
       
        }
        return Ok(result);
    }
}
