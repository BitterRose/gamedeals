using System.Net;
using System.Text.Json;

namespace GameDeals.Api.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
	private readonly ILogger _logger;

	public ErrorHandlingMiddleware(ILogger logger)
	{
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception error)
		{
			_logger.LogError(error, error.Message);

			var response = context.Response;
			response.ContentType = "application/json";
			switch (error)
			{
				case KeyNotFoundException ex:
					response.StatusCode = (int)HttpStatusCode.NotFound;
					break;
				case UnauthorizedAccessException ex:
					response.StatusCode = (int)HttpStatusCode.Unauthorized;
					break;
				default:
					response.StatusCode = (int)HttpStatusCode.InternalServerError;
					break;
			}
			var result = JsonSerializer.Serialize(new { message = error?.Message });
			await response.WriteAsync(result);
		}
	}
}
