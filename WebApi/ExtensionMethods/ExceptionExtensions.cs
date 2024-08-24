using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Services.ServiceContracts;
using System.Net;

namespace WebApi.ExtensionMethods
{
	public static class ExceptionExtensions
	{
		public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //StatusCodes.Status500InternalServerError;(ilerde customize edilecek simdilik 500 atayalım)
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature is not null) //null degilse hata gelmis demektir, boyle de yazılabilir contextFeature?.Error is FileNotFoundException
					{
						logger.LogError($"Something went wrong: {contextFeature.Error}");
						await context.Response.WriteAsync(new ErrorDetails()
						{
							StatusCode = context.Response.StatusCode,
							Message = "Internal Server Error"
						}.ToString());
					}
				});
			});
		}
	}
}
