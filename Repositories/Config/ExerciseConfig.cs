using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Enums;

namespace Repositories.Config
{
	public class ExerciseConfig : IEntityTypeConfiguration<Exercise>
	{
		public void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.HasIndex(e => e.Name).IsUnique(); //egzersşzlerin isimleri unique olmalı (benzersiz)

			builder.Property(e => e.Name)
			.HasMaxLength(100)
			.IsRequired(); // Zorunlu alan

			builder.Property(e => e.Difficulty)
	   .HasConversion<int>(); // Enum değerini integer olarak saklar

			builder.HasData(
			new Exercise
			{
				Id = 1,
				Name = "Squat",
				Description = "Lower body strength exercise",
				Difficulty = DifficultyLevel.VeryEasy,
				CategoryId = 1
			},
			new Exercise
			{
				Id = 2,
				Name = "Bench Press",
				Description = "Upper body strength exercise",
				Difficulty = DifficultyLevel.Medium,
				CategoryId = 1
			},
			new Exercise
			{
				Id = 3,
				Name = "Running",
				Description = "Cardio exercise",
				Difficulty = DifficultyLevel.Medium,
				CategoryId = 2
			},
			new Exercise
			{
				Id = 4,
				Name = "Freestyle Swimming",
				Description = "Front crawl swimming style",
				Difficulty = DifficultyLevel.Easy,
				CategoryId = 2
			},
			new Exercise
			{
				Id = 5,
				Name = "Breaststroke Swimming",
				Description = "Breaststroke swimming style",
				Difficulty = DifficultyLevel.Medium,
				CategoryId = 2
			},
			new Exercise
			{
				Id = 6,
				Name = "Deadlift",
				Description = "Lower body and back strength exercise",
				Difficulty = DifficultyLevel.Hard,
				CategoryId = 1
			});
		}
	}
}
