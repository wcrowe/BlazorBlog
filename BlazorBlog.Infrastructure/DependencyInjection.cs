using BlazorBlog.Application.Authentication;
using BlazorBlog.Domain.Articles;
using BlazorBlog.Infrastructure.Authentication;
using BlazorBlog.Infrastructure.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorBlog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            AddAuthentication(services);
            services.AddScoped<IArticleRepository, ArticleRepository>();
            return services;
        }


        private static void AddAuthentication(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddCascadingAuthenticationState();
            services.AddAuthorization();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;

                option.DefaultSignInScheme = IdentityConstants.ExternalScheme;

            }).AddIdentityCookies();
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
        }
    }
}