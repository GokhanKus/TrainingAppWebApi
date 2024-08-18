using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	//public class AppUserConfig : IEntityTypeConfiguration<AppUser>
	//{
	//	public void Configure(EntityTypeBuilder<AppUser> builder)
	//	{
	//		var hasher = new PasswordHasher<AppUser>();

	//		builder.HasData(
	//			new AppUser
	//			{
	//				Id = "user1-id",
	//				UserName = "john_doe",
	//				NormalizedUserName = "JOHN_DOE",
	//				Email = "john@example.com",
	//				NormalizedEmail = "JOHN@EXAMPLE.COM",
	//				EmailConfirmed = true,
	//				PasswordHash = hasher.HashPassword(null, "John123!"),
	//				FirstName = "John",
	//				LastName = "Doe"
	//			},
	//			new AppUser
	//			{
	//				Id = "user2-id",
	//				UserName = "jane_doe",
	//				NormalizedUserName = "JANE_DOE",
	//				Email = "jane@example.com",
	//				NormalizedEmail = "JANE@EXAMPLE.COM",
	//				EmailConfirmed = true,
	//				PasswordHash = hasher.HashPassword(null, "Jane123!"),
	//				FirstName = "Jane",
	//				LastName = "Doe"
	//			}
	//		);
	//	}
	//}
}
