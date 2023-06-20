using Microsoft.AspNetCore.Authorization;

namespace GameDeals.Application.Policies.AnyRole;
public class AnyRoleRequirementHandler : AuthorizationHandler<AnyRoleRequirement>
{
	protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AnyRoleRequirement requirement)
	{
		if (context.User.IsInRole("Admin") || context.User.IsInRole("User"))
		{
			context.Succeed(requirement);
		}
		return Task.CompletedTask;
	}
}
