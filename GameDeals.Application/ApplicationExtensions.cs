using GameDeals.Application.Interfaces;
using GameDeals.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameDeals.Application;
public static class InfrastructureExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<IUsersService, UsersService>();
		return services;
	}
}
