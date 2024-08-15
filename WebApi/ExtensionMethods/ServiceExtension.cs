using Microsoft.EntityFrameworkCore;
using Repositories.Context;

namespace WebApi.ExtensionMethods
{
	public static class ServiceExtension
	{
		public static void SqlConfiguration(this IServiceCollection services, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("sqlConnection");
			services.AddDbContext<RepositoryContext>(options =>
			{
				options.UseSqlServer(connectionString, migr => migr.MigrationsAssembly(nameof(WebApi)));
				options.EnableSensitiveDataLogging(true);//app gelistirme asamasinda username password gibi hassas bilgileri loglara yansitmaya ihtiyac duyabiliriz. simdilik true yapalim
			});
		}
	}
}
