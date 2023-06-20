using Microsoft.AspNetCore.Authorization;

namespace GameDeals.Application.Policies.AdminRole;

public class AdminRoleRequirement : IAuthorizationRequirement
{
	public AdminRoleRequirement()
	{
	}
}

