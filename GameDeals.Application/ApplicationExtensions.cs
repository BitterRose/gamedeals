using GameDeals.Application.Genre.Interfaces;
using GameDeals.Application.Genre.Services;
using GameDeals.Application.Users.Interfaces;
using GameDeals.Application.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using GameDeals.Application.Policies.AdminRole;
using GameDeals.Application.Policies.AnyRole;
using Microsoft.AspNetCore.Authorization;

namespace GameDeals.Application;
public static class InfrastructureExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<IUsersService, UsersService>();
		services.AddScoped<IGenreService, GenreService>();
		services.AddSingleton<IAuthorizationHandler, AdminRoleRequirementHandler>();
		services.AddSingleton<IAuthorizationHandler, AnyRoleRequirementHandler>();

		services.AddAuthorizationCore(services =>
		{
			services.AddPolicy("AdminRole", policy => policy.Requirements.Add(new AdminRoleRequirement()));
			services.AddPolicy("AnyRole", policy => policy.Requirements.Add(new AnyRoleRequirement()));
		});
		return services;
	}
}
