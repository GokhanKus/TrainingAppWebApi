using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// WorkoutExercise Configuration
			modelBuilder.Entity<WorkoutExercise>()
				.HasKey(we => new { we.WorkoutId, we.ExerciseId }); // Composite Key tanımlama

			modelBuilder.Entity<WorkoutExercise>()
				.HasOne(we => we.Workout)
				.WithMany(w => w.WorkoutExercises)
				.HasForeignKey(we => we.WorkoutId);

			modelBuilder.Entity<WorkoutExercise>()
				.HasOne(we => we.Exercise)
				.WithMany(e => e.WorkoutExercises)
				.HasForeignKey(we => we.ExerciseId);

			// Diğer entity'ler için konfigürasyonlar buraya eklenebilir
		}
		public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
		public DbSet<Exercise> Exercise { get; set; }
		public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
		public DbSet<Workout> Workouts { get; set; }
		public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
	}
}
