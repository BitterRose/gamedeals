using Microsoft.AspNetCore.Authorization;

namespace GameDeals.Application.Policies.AdminRole;

public class AnyRoleRequirement : IAuthorizationRequirement
{
	public AnyRoleRequirement()
	{
	}
}

