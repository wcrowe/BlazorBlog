﻿namespace BlazorBlog.Application.Users.RemoveRoleFromUser;

public class RemoveRoleFromUserCommandHandler : ICommandHandler<RemoveRoleFromUserCommand>
{
    private readonly IUserService _userService;

    public RemoveRoleFromUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.RemoveRoleFromUserAsync(request.UserId, request.RoleName);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Failed to remove role from user: {ex.Message}");
        }
    }
}
