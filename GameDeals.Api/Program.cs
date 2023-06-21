using GameDeals.Api.Middleware;
using GameDeals.Application;
using GameDeals.Infrastructure;
using GameDeals.Infrastructure.DbContexts;
using Microsoft.OpenApi.Models;

namespace GameDeals.Api;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddScoped<ErrorHandlingMiddleware>();
		builder.Services.AddApplication();
		builder.Services.AddInfrastructure(builder.Configuration);
		
		builder.Services.AddProblemDetails();
		builder.Services.AddAuthentication();
		builder.Services.AddAuthorization();

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(swaggerGenOptions =>
		{
			swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Name = "Authorization",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = "Bearer",
				BearerFormat = "JWT",
				Description = "Authorization using the Bearer scheme.",
			});

			swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						},
						Scheme = "bearer",
						Name = "Bearer",
						In = ParameterLocation.Header,
					},
					new List<string>()
				}
			});

		});

		var app = builder.Build();
		app.UseHttpsRedirection();
		app.UseMiddleware<ErrorHandlingMiddleware>();

		app.UseSwagger();
		app.UseSwaggerUI();

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();
		await app.SeedContext();
		app.Run();
	}
}
