using Microsoft.AspNetCore.Authorization;

namespace GameDeals.Application.Policies.AnyRole;

public class AnyRoleRequirement : IAuthorizationRequirement
{
	public AnyRoleRequirement()
	{
	}
}

