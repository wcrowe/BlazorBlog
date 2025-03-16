
using BlazorBlog.Application;
using BlazorBlog.Infrastructure;
using BlazorBlog.WebUI.Server;
using Microsoft.AspNetCore.Components.WebAssembly.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents();
builder.Services.AddApplication(); // Ensure that AddApplication is defined in the Extensions namespace
builder.Services.AddInfrastructure(builder.Configuration); // Ensure that AddInfrastructure is defined in the Extensions namespace   

builder.Services.AddControllers();

// ✅ Register HttpClient for the server project
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AllowAnonymous()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorBlog.WebUI.Client._Imports).Assembly);

//[RenderModels].AddInteractiveServerRenderMode().AddAdditionalAssemblies(typeof(Client._Imports).Assembly)
//.AllowAnonymous();

app.Run();
