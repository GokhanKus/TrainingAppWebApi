﻿using AspNetCoreRateLimit;
using Newtonsoft.Json;
using NLog;
using Services.Mapper;
using Services.ServiceContracts;
using StackExchange.Redis;
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
			LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); //nlogu baslatip nlog.config dosyasindaki yapýlandirmayi yukler


			builder.Services.AddAutoMapper(typeof(MappingProfile)); // services/Mapper/MappingProfile
																	//nlogu baslatip nlog.config dosyasindaki yapýlandirmayi yukler

			builder.Services.ConfigureCors();
			builder.Services.DataShaperInjections();
			builder.Services.ActionFilterInjections();
			builder.Services.SqlConfiguration(builder.Configuration);
			builder.Services.RepositoryInjections();
			builder.Services.ServiceInjections();
			builder.Services.LoggerServiceInjection();
			builder.Services.ConfigureIdentityDbContext();
			builder.Services.ConfigureJWT(builder.Configuration);
			builder.Services.AddCustomMediaTypes();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddMemoryCache();
			builder.Services.AddHttpContextAccessor();
			builder.Services.ConfigureRateLimiting(builder.Configuration);

			builder.Services.AddRedisImplementation(builder.Configuration);

			var app = builder.Build(); //app'i elde ettigimiz asama bu satir'dan sonra ihtiyac duyulan servisler alinabilir.

			var logger = app.Services.GetRequiredService<ILoggerService>();
			app.ConfigureExceptionHandler(logger);

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				IdentityDataSeeding.IdentityTestUsers(app);
			}

			if (app.Environment.IsProduction())
				app.UseHsts();

			app.UseIpRateLimiting();

			app.UseCors("CorsPolicy");

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
