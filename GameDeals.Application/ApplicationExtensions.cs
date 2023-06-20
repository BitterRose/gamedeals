using GameDeals.Application.Game.Interfaces;
using GameDeals.Application.Game.Services;
using GameDeals.Application.Genre.Interfaces;
using GameDeals.Application.Genre.Services;
using GameDeals.Application.Policies.AdminRole;
using GameDeals.Application.Policies.AnyRole;
using GameDeals.Application.Review.Interfaces;
using GameDeals.Application.Review.Services;
using GameDeals.Application.Users.Interfaces;
using GameDeals.Application.Users.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace GameDeals.Application;
public static class InfrastructureExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IGenreService, GenreService>();
		services.AddScoped<IGameService, GameService>();
		services.AddScoped<IReviewService, ReviewService>();

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
