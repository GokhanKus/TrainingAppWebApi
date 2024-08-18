using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi.ExtensionMethods
{
	public static class IdentityDataSeeding
	{
		private const string adminUser = "admin";
		private const string adminPassword = "Admin_123";
		private const string regularUser = "user";
		private const string regularUserPassword = "User_123";

		private const string adminRole = "Admin";
		private const string userRole = "User";

		public static async void IdentityTestUsers(IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();

				if (!context.Database.GetAppliedMigrations().Any())
				{
					context.Database.Migrate();
				}

				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

				// Admin ve User rolleri oluşturuluyor
				if (!await roleManager.RoleExistsAsync(adminRole))
				{
					await roleManager.CreateAsync(new AppRole { Name = adminRole });
				}

				if (!await roleManager.RoleExistsAsync(userRole))
				{
					await roleManager.CreateAsync(new AppRole { Name = userRole });
				}

				// Admin kullanıcı oluşturuluyor ve Admin rolü atanıyor
				var admin = await userManager.FindByNameAsync(adminUser);
				if (admin == null)
				{
					admin = new AppUser
					{
						FirstName = "John",
						LastName = "Doe",
						UserName = adminUser,
						Email = "john.doe@example.com",
						PhoneNumber = "123456789"
					};

					var adminResult = await userManager.CreateAsync(admin, adminPassword);

					if (adminResult.Succeeded)
					{
						await userManager.AddToRoleAsync(admin, adminRole); // Admin rolü atanıyor
					}
				}

				// User kullanıcı oluşturuluyor ve User rolü atanıyor
				var user = await userManager.FindByNameAsync(regularUser);
				if (user == null)
				{
					user = new AppUser
					{
						FirstName = "Jane",
						LastName = "Doe",
						UserName = regularUser,
						Email = "jane.doe@example.com",
						PhoneNumber = "987654321"
					};

					var userResult = await userManager.CreateAsync(user, regularUserPassword);

					if (userResult.Succeeded)
					{
						await userManager.AddToRoleAsync(user, userRole); // User rolü atanıyor
					}
				}
			}
		}
	}


}
