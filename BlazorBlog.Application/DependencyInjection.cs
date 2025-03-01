﻿using BlazorBlog.Application.Articles;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorBlog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));   

            return services;
        }
    }
}
