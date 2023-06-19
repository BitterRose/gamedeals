using GameDeals.Application.Interfaces;
using GameDeals.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameDeals.Application;
public static class InfrastructureExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddSingleton<IUsersService, UsersService>();
		services.AddSingleton<IAuthenticationService, AuthenticationService>();
		return services;
	}
}
