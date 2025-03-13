using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BlazorBlog.Infrastructure;

public class AuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{
    public Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
    {
        return next(context);
    }
}