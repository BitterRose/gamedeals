using Microsoft.AspNetCore.Authorization;

namespace GameDeals.Application.Policies.AdminRole;
internal class AdminRoleRequirementHandler : AuthorizationHandler<AdminRoleRequirement>
{
	protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRoleRequirement requirement)
	{
		if (context.User.IsInRole("Admin"))
		{
			context.Succeed(requirement);
		}
		return Task.CompletedTask;
	}
}
