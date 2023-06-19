using GameDeals.Domain.Services;
using GameDeals.Infrastructure.DbContexts;
using GameDeals.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameDeals.Infrastructure;
public static class InfrastructureExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			string? connectionString = configuration.GetConnectionString("ApplicationDatabase");
			ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

			options.UseSqlite(connectionString);
		});

		services.AddSingleton<IPasswordHasher<object>, PasswordHasher<object>>();
		services.AddSingleton<IPasswordManager, PasswordManager>();
		return services;
	}
}
