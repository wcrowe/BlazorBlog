using BlazorBlog.Application.Articles.GetArticles;

namespace BlazorBlog.Application.Users.GetUsers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public GetUsersQueryHandler(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (!await _userService.IsCurrentUserInRoleAsync("Admin"))
        {
            return Result.Fail<List<UserResponse>>("You do not have permission to view users.");
        }
        var users = await _userRepository.GetAllUsersAsync();
        var response = new List<UserResponse>();
        foreach (var user in users)
        {
            var userResponses = user.Adapt<UserResponse>();
            userResponses.Roles = string.Join(", ", await _userService.GetUserRolesAsync(user.Id));
            response.Add(userResponses);

        }
        return response;
        // return Result.Ok(users.Adapt<List<UserResponse>>());
    }
}
