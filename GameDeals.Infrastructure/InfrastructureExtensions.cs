using GameDeals.Domain.Repositories;
using GameDeals.Domain.Services;
using GameDeals.Infrastructure.DbContexts;
using GameDeals.Infrastructure.Repositories;
using GameDeals.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

		services.AddAuthentication(authenticationOptions =>
		{
			authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			authenticationOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(jwtBearerOptions =>
		{
			jwtBearerOptions.RequireHttpsMetadata = true;
			jwtBearerOptions.SaveToken = true;
			jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
			{
				ValidIssuer = "https://localhost:7127",
				ValidateIssuer = true,

				RequireSignedTokens = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7LyqiTXsZInsa5ZW7LyqiTXsZInsa5ZW7LyqiTXsZInsa5ZW7LyqiTXsZInsa5ZW")),
				ValidateIssuerSigningKey = true,

				RequireAudience = true,
				ValidAudience = "https://localhost:7127",
				ValidateAudience = true,

				RequireExpirationTime = true,
				ClockSkew = TimeSpan.Zero,
				ValidateLifetime = true,
			};
		});

		services.AddScoped<IUsersRepository, UsersRepository>();
		services.AddScoped<IJwtService, JwtService>();
		services.AddSingleton<IPasswordHasher<object>, PasswordHasher<object>>();
		services.AddSingleton<IPasswordManagerService, PasswordManagerService>();

		return services;
	}
}
