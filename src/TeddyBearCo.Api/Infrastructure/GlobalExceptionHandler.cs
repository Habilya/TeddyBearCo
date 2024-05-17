using Microsoft.AspNetCore.Diagnostics;

namespace TeddyBearCo.Api.Infrastructure;

public class GlobalExceptionHandler : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(
		HttpContext httpContext,
		Exception exception,
		CancellationToken cancellationToken)
	{
		var guid = Guid.NewGuid();
		// could log that guid to be referenced and looked up

		httpContext.Response.StatusCode = 500;
		httpContext.Response.ContentType = "application/json";

		await httpContext.Response.WriteAsJsonAsync(new
		{
			StatusCode = httpContext.Response.StatusCode,
			Title = "Internal Server Error",
			Message = $"ref.: {guid}"
		});

		return true;
	}
}
