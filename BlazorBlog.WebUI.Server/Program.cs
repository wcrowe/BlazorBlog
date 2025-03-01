using BlazorBlog.WebUI.Server.Components;
using BlazorBlog.Application;
using BlazorBlog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddApplication(); // Ensure that AddApplication is defined in the Extensions namespace
builder.Services.AddInfrastructure(builder.Configuration); // Ensure that AddInfrastructure is defined in the Extensions namespace   



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
