using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentation.ActionFilters;
using Repositories.Context;
using Repositories.DistributedCacheRepos;
using Repositories.MemoryCachedRepos;
using Repositories.RepoConcretes;
using Repositories.UnitOfWork;
using Services.ServiceConcretes;
using Services.ServiceContracts;
using System.Text;

namespace WebApi.ExtensionMethods
{
	public static class ServiceExtension
	{
		public static void SqlConfiguration(this IServiceCollection service, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("sqlConnection");
			service.AddDbContext<RepositoryContext>(options =>
			{
				options.UseSqlServer(connectionString, migr => migr.MigrationsAssembly(nameof(WebApi)));
				options.EnableSensitiveDataLogging(true);//app gelistirme asamasinda username password gibi hassas bilgileri loglara yansitmaya ihtiyac duyabiliriz. simdilik true yapalim
														 //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});
		}
		public static void RepositoryInjections(this IServiceCollection service)
		{
			service.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepository>();
			service.Decorate<IBodyMeasurementRepository, RedisCacheBodyMeasurementRepository>();
			//service.Decorate<IBodyMeasurementRepository, CachedBodyMeasurementRepository>(); this is for InMemoryCache

			service.AddScoped<IExerciseCategoryRepository, ExerciseCategoryRepository>();
			service.Decorate<IExerciseCategoryRepository, CachedExerciseCategoryRepository>();

			service.AddScoped<IExerciseRepository, ExerciseRepository>();
			service.Decorate<IExerciseRepository, CachedExerciseRepository>();

			service.AddScoped<IWorkoutRepository, WorkoutRepository>();
			service.Decorate<IWorkoutRepository, CachedWorkoutRepository>();

			service.AddScoped<IUnitOfWork, UnitOfWork>();
		}
		public static void ServiceInjections(this IServiceCollection service)
		{
			service.AddScoped<IExerciseService, ExerciseService>();
			service.AddScoped<IExerciseCategoryService, ExerciseCategoryService>();
			service.AddScoped<IBodyMeasurementService, BodyMeasurementService>();
			service.AddScoped<IWorkoutService, WorkoutService>();
			service.AddScoped<IAuthService, AuthService>();
		}

		public static void ConfigureIdentityDbContext(this IServiceCollection service)
		{
			service.AddIdentity<AppUser, AppRole>(opt =>
			{
				opt.Password.RequireDigit = true; //kayit islemi sırasinda rakam zorunlulu
				opt.Password.RequireUppercase = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireNonAlphanumeric = false; //& % + gibi karakterler zorunlu olmasin
				opt.Password.RequiredLength = 6; //min 6 karakter
				opt.User.RequireUniqueEmail = true;//mailler unique olsun her userin maili kendine ait olsun vs.
				opt.SignIn.RequireConfirmedAccount = false; //kayit isleminden sonra e posta onaylama zorunlulugu olmasin
			})
				.AddEntityFrameworkStores<RepositoryContext>()
				.AddDefaultTokenProviders(); //jwt kullanacagiz ve sifre, mail, resetleme, degistirme, mail onaylama gibi islemler icin gereken token bilgisini üretmek icin AddDefaultTokenProviders().
		}
		public static void ConfigureJWT(this IServiceCollection service, IConfiguration config)
		{
			var jwtSettings = config.GetSection("jwtSettings");
			var secretKey = jwtSettings.GetValue<string>("secretKey"); //jwtSettings["secretKey"];
																	   //authentication icin default semalar
			service.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = jwtSettings["validIssuer"],
					ValidAudience = jwtSettings["validAudience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
				};
			});
		}
		public static void LoggerServiceInjection(this IServiceCollection service)
		{
			service.AddSingleton<ILoggerService, LoggerService>();
		}
		public static void ActionFilterInjections(this IServiceCollection service)
		{
			//bagimlilik gerektiren attr'ler icin servis kaydi yapilir ornegin LogFilterAttribute classi ILogger gibi bir bagimliligi kullaniyor;
			//o yuzden IoC kaydi yapilir ve [ServiceFilter(typeof(LogFilterAttribute))] yazarak kullanilabilir
			//ama ValidationFilterAttribute attr icin boyle bir durum soz konusu degil;
			//o yuzden onu controller seviyesinde ya da action bazında direkt [ValidationFilter] yazarak kullanabiliriz.

			//services.AddScoped<ValidationFilterAttribute>();
			service.AddSingleton<LogFilterAttribute>(); //loglama islemi icin sadece bir tane nesnenin olusmasi yeterli o yuzden singleton
		}
		public static void AddRedisImplementation(this IServiceCollection service, IConfiguration config)
		{
			var redisConnectionString = config.GetConnectionString("Redis");
			service.AddStackExchangeRedisCache(redisOptions =>
			{
				redisOptions.Configuration = redisConnectionString;
			});
		}
	}
}
