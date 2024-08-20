using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.RepoConcretes;
using Repositories.UnitOfWork;
using Services.ServiceConcretes;
using Services.ServiceContracts;

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
			service.AddScoped<IExerciseCategoryRepository, ExerciseCategoryRepository>();
			service.AddScoped<IExerciseRepository, ExerciseRepository>();
			service.AddScoped<IWorkoutRepository, WorkoutRepository>();
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

		public static void ConfigureIdentityDbContext(this IServiceCollection services)
		{
			services.AddIdentity<AppUser, AppRole>(opt =>
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
	}
}
