using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBlog.WebUI.Client;
using Client = BlazorBlog.WebUI.Client.Features.Articles;
using BlazorBlog.Application.Articles;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped(sp => new HttpClient {
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});


builder.Services.AddScoped<IArticleOverviewService, Client.ArticleOverviewService>();

await builder.Build().RunAsync();
