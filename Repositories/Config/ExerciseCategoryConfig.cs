using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
	public class ExerciseCategoryConfig : IEntityTypeConfiguration<ExerciseCategory>
	{
		public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
		{
			builder.HasData(
			new ExerciseCategory
			{
				Id = 1,
				Name = "Strength",
				Description = "Strength training exercises"
			},
			new ExerciseCategory
			{
				Id = 2,
				Name = "Cardio",
				Description = "Cardio exercises"
			},
			new ExerciseCategory
			{
				Id = 3,
				Name = "Flexibility",
				Description = "Flexibility exercises"
			},
			new ExerciseCategory
			{
				Id = 4,
				Name = "Swimming",
				Description = "Swimming exercises and styles"
			});
		}
	}

}
