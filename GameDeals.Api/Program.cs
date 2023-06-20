using GameDeals.Application;
using GameDeals.Infrastructure;
using GameDeals.Infrastructure.DbContexts;

namespace GameDeals.Api;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddProblemDetails();

		builder.Services.AddApplication();
		builder.Services.AddInfrastructure(builder.Configuration);

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		app.UseAuthentication();
		app.UseAuthorization();
		app.MapControllers();
		await app.SeedContext();

		app.Run();
	}
}
