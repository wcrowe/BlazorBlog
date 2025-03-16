using BlazorBlog.Application.Articles;
using System.Net.Http.Json;

namespace BlazorBlog.WebUI.Client.Features.Articles;

public class ArticleOverviewService : IArticleOverviewService
{
    private readonly HttpClient _httpClient;

    public ArticleOverviewService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ArticleResponse>>("api/articles");
    }

    public async Task<ArticleResponse?> TogglePublishArticleAsync(int articlId)
    {
        var results = await _httpClient.PatchAsync($"api/articles/{articlId}", null);
        if (results is not null && results.Content is not null)
        {
            return await results.Content.ReadFromJsonAsync<ArticleResponse>();
        }
        return null;
    }
}
