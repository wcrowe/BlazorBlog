

namespace BlazorBlog.Application.Users.AddRoleToUser;

public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand>
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public AddRoleToUserCommandHandler(IUserService userService, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task<Result> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return Result.Fail("User not found");
        }

        var userRoles = await _userService.GetUserRolesAsync(request.UserId);
        if (userRoles.Contains(request.RoleName))
        {
            return Result.Fail("User already has this role");
        }

        try
        {
            await _userService.AddRoleToUserAsync(request.UserId, request.RoleName);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Failed to add role to user: {ex.Message}");
        }
    }
}
