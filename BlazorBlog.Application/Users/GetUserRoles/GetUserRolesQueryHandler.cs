
namespace BlazorBlog.Application.Users.GetUserRoles;

public class GetUserRolesQueryHandler(IUserService userService) : IQueryHandler<GetUserRolesQuery, List<string>>
{
    private readonly IUserService _userService = userService;

    public async Task<Result<List<string>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _userService.GetUserRolesAsync(request.UserId);
        return Result.Ok(roles);
    }
}
