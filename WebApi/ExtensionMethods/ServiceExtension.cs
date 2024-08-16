using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.RepoConcretes;
using Repositories.UnitOfWork;

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
		}
	}
}
