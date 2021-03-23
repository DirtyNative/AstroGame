using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Refit;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace AstroGame.Shared.Middlewares
{
    [TransientService]
    public class ExceptionHandlerMiddleware : IMiddleware
    {
		private readonly ILogger<ExceptionHandlerMiddleware> _logger;

		public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
		{
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex) when (ex is IHttpException eh)
			{
				// The Statuscode must be set manually in order to return the correct one
				context.Response.StatusCode = (int)eh.StatusCode;
				context.Response.ContentType = "application/json";

				var json = JsonConvert.SerializeObject(new
				{
					eh.Message,
					ex.StackTrace
				});
				await context.Response.WriteAsync(json);

				// Because this is a managed exception, we don't want to log higher than warning
				_logger.LogWarning(ex, eh.Message);
			}
			// This exception type is thrown when something inside the services occurs
			catch (ApiException apiEx)
			{
				// The Statuscode must be set manually in order to return the correct one
				context.Response.StatusCode = (int)apiEx.StatusCode;
				context.Response.ContentType = "application/json";

				await context.Response.WriteAsync(apiEx.Content);

				// No need to log the exception because service already did
			}
			catch (Exception ex) when (ex is HttpResponseException httpEx)
			{
				// The Statuscode must be set manually in order to return the correct one
				context.Response.StatusCode = (int)httpEx.Response.StatusCode;
				context.Response.ContentType = "application/json";

				if (httpEx.Response.Content != null)
					await context.Response.WriteAsync(await httpEx.Response.Content.ReadAsStringAsync());
			}
			catch (Exception ex)
			{
				// The Statuscode must be set manually in order to return the correct one
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				context.Response.ContentType = "application/json";

				var json = JsonConvert.SerializeObject(new
				{
					ex.Message,
					ex.StackTrace
				});
				await context.Response.WriteAsync(json);

				// When this exception occurs, there is a real thick problem like any black girls booty... Fix this!
				_logger.LogCritical(ex, ex.Message);
			}
		}
	}
}
