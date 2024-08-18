using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
	public class WorkoutConfig : IEntityTypeConfiguration<Workout>
	{
		public void Configure(EntityTypeBuilder<Workout> builder)
		{

			builder.HasOne(w => w.User)
			 .WithMany(u => u.Workouts)
			 .HasForeignKey(w => w.UserId)
			 .OnDelete(DeleteBehavior.Cascade);
			//user silinirse user'a ait antrenman bilgileri de silinsin

			builder.HasData(
			new Workout
			{
				Id = 1,
				Date = DateTime.Now.AddDays(-10),
				Duration = 60,
				TotalCaloriesBurned = 500,
				Notes = "Leg day workout",
				UserId = "a3058765-ecf0-403e-9d48-08b38d4888ab" //John Doe(admin)'nun workout'u 
			},
			new Workout
			{
				Id = 2,
				Date = DateTime.Now.AddDays(-5),
				Duration = 45,
				TotalCaloriesBurned = 400,
				Notes = "Upper body workout",
				UserId = "a3058765-ecf0-403e-9d48-08b38d4888ab" //John Doe(admin)'nun workout'u 
			}, new Workout
			{
				Id = 3,
				Date = DateTime.Now.AddDays(-7),
				Duration = 40,
				TotalCaloriesBurned = 300, 
				Notes = "Freestyle swimming session",
				UserId = "8cee140a-65fd-495d-970b-5315a6f3e7b2" //Jane Doe(user)'nun workout'u
			},
			new Workout
			{
				Id = 4,
				Date = DateTime.Now.AddDays(-3),
				Duration = 50,
				TotalCaloriesBurned = 350,
				Notes = "Breaststroke swimming session",
				UserId = "8cee140a-65fd-495d-970b-5315a6f3e7b2" //Jane Doe(user)'nun workout'u
			});
		}
	}
}
