using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Repositories.Config
{
	public class WorkoutExerciseConfig : IEntityTypeConfiguration<WorkoutExercise>
	{
		public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
		{
			// WorkoutExercise Configuration
			builder
				.HasKey(we => new { we.WorkoutId, we.ExerciseId }); // Composite Key tanımlama

			builder
				.HasOne(we => we.Workout)
				.WithMany(w => w.WorkoutExercises)
				.HasForeignKey(we => we.WorkoutId);

			builder
				.HasOne(we => we.Exercise)
				.WithMany(e => e.WorkoutExercises)
				.HasForeignKey(we => we.ExerciseId);

			// Diğer entity'ler için konfigürasyonlar buraya eklenebilir
			builder.HasData(
			new WorkoutExercise
			{
				WorkoutId = 1,
				ExerciseId = 1,
				Sets = 4,
				Reps = 10,
				Weight = 80
			},
			new WorkoutExercise
			{
				WorkoutId = 1,
				ExerciseId = 3,
				Distance = 5 // Running 
			},
			new WorkoutExercise
			{
				WorkoutId = 2,
				ExerciseId = 2,
				Sets = 3,
				Reps = 12,
				Weight = 60
			},
			new WorkoutExercise
			{
				WorkoutId = 3,
				ExerciseId = 4, // Freestyle Swimming
				Distance = 1.5f // 1.5 km
			},
			new WorkoutExercise
			{
				WorkoutId = 4,
				ExerciseId = 5, // Breaststroke Swimming
				Distance = 2f // 2 km
			});
		}
	}
}
