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
		builder.Services.AddProblemDetails();

		builder.Services.AddApplication();
		builder.Services.AddInfrastructure(builder.Configuration);
		builder.Services.AddAuthentication();
		builder.Services.AddAuthorization();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		app.UseMiddleware<ErrorHandlingMiddleware>();
		app.UseAuthentication();
		app.UseAuthorization();
		app.MapControllers();
		await app.SeedContext();

		app.Run();
	}
}
