using Newtonsoft.Json;
using WebApi.ExtensionMethods;

namespace WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers()
				.AddNewtonsoftJson(opt =>
				{
					opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					opt.SerializerSettings.DateFormatString = "dd/MM/yyyy";
				})
				.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

			builder.Services.SqlConfiguration(builder.Configuration);
			builder.Services.RepositoryInjections();
			builder.Services.ServiceInjections();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			//app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
