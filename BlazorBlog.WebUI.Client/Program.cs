using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBlog.WebUI.Client;
using BlazorBlog.Application.Articles;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});


builder.Services.AddScoped<IArticleOverviewService, BlazorBlog.WebUI.Client.Features.Articles.ArticleOverviewService>();

await builder.Build().RunAsync();
