﻿using BlazorBlog.Application.Authentication;
using BlazorBlog.Domain.Articles;
using BlazorBlog.Infrastructure.Authentication;
using BlazorBlog.Infrastructure.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BlazorBlog.Infrastructure.Users;
using BlazorBlog.Application.Users;
using BlazorBlog.Domain.Users;
using BlazorBlog.Application.Articles;


namespace BlazorBlog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
        AddAuthentication(services);
        services.AddHttpContextAccessor();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUserRepository, UserRepositiory>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IArticleOverviewService, ArticleOverviewService>();

        return services;
    }


    private static void AddAuthentication(IServiceCollection services)
    {
        //     services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
        services.AddHttpContextAccessor(); // Needed for IHttpContextAccessor
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddCascadingAuthenticationState();
        services.AddAuthorization();
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();
        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
    }
}