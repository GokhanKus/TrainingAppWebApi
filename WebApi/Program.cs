using Newtonsoft.Json;
using NLog;
using Services.Mapper;
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

			builder.Services.AddAutoMapper(typeof(MappingProfile)); // services/Mapper/MappingProfile

			LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
			//nlogu baslatip nlog.config dosyasindaki yapýlandirmayi yukler

			builder.Services.SqlConfiguration(builder.Configuration);
			builder.Services.RepositoryInjections();
			builder.Services.ServiceInjections();
			builder.Services.LoggerService();
			builder.Services.ConfigureIdentityDbContext();
			builder.Services.ConfigureJWT(builder.Configuration);

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			// Configure the HTTP request pipeline.


			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				IdentityDataSeeding.IdentityTestUsers(app);
			}

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
